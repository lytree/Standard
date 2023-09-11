﻿using FreeSql.Aop;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yitter.IdGenerator;
using FreeSql.DataAnnotations;
using Infrastructure;

namespace Repository.Admin.Core;

public class DbHelper
{
    /// <summary>
    /// 偏移时间
    /// </summary>
    private static TimeSpan timeOffset;

    public static TimeSpan TimeOffset { get => timeOffset; set => timeOffset = value; }

    /// <summary>
    /// 创建数据库
    /// </summary>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    public async static Task CreateDatabaseAsync(DataType dbType, string? createDbSql, string? createDbConnectionString)
    {
        if (string.IsNullOrEmpty(createDbSql) || dbType == DataType.Sqlite)
        {
            return;
        }

        var db = new FreeSqlBuilder()
                .UseConnectionString(dbType, createDbConnectionString)
                .Build();

        try
        {
            await db.Ado.ExecuteNonQueryAsync(createDbSql);
            Console.WriteLine("create database succeed");
        }
        catch (Exception e)
        {
            Console.WriteLine($"create database failed.\n {e.Message}");
        }
    }

    /// <summary>
    /// 获得指定程序集表实体
    /// </summary>
    /// <param name="assemblyNames"></param>
    /// <returns></returns>
    public static Type[] GetEntityTypes(string[] assemblyNames)
    {
        if (!(assemblyNames?.Length > 0))
        {
            return null;
        }

        var entityTypes = new List<Type>();

        foreach (var assemblyName in assemblyNames)
        {
            var assembly = Assembly.Load(assemblyName);
            foreach (Type type in assembly.GetExportedTypes())
            {
                foreach (Attribute attribute in type.GetCustomAttributes())
                {
                    if (attribute is TableAttribute tableAttribute)
                    {
                        if (tableAttribute.DisableSyncStructure == false)
                        {
                            entityTypes.Add(type);
                        }
                    }
                }
            }
        }

        return entityTypes.ToArray();
    }


    /// <summary>
    /// 审计数据
    /// </summary>
    /// <param name="e"></param>
    /// <param name="timeOffset"></param>
    /// <param name="user"></param>
    public static void AuditValue(AuditValueEventArgs e, TimeSpan timeOffset, IUser user)
    {
        //数据库时间
        if ((e.Column.CsType == typeof(DateTime) || e.Column.CsType == typeof(DateTime?))
        && e.Property.GetCustomAttribute<ServerTimeAttribute>(false) != null
        && (e.Value == null || (DateTime)e.Value == default || (DateTime?)e.Value == default))
        {
            e.Value = DateTime.Now.Subtract(timeOffset);
        }

        //雪花Id
        if (e.Column.CsType == typeof(long)
        && e.Property.GetCustomAttribute<SnowflakeAttribute>(false) is SnowflakeAttribute snowflakeAttribute
        && snowflakeAttribute.Enable && (e.Value == null || (long)e.Value == default || (long?)e.Value == default))
        {
            e.Value = YitIdHelper.NextId();
        }

        //有序Guid
        if (e.Column.CsType == typeof(Guid)
        && e.Property.GetCustomAttribute<OrderGuidAttribute>(false) is OrderGuidAttribute orderGuidAttribute
        && orderGuidAttribute.Enable && (e.Value == null || (Guid)e.Value == default || (Guid?)e.Value == default))
        {
            e.Value = FreeUtil.NewMongodbId();
        }

        if (user == null || user.Id <= 0)
        {
            return;
        }

        if (e.AuditValueType is AuditValueType.Insert or AuditValueType.InsertOrUpdate)
        {
            switch (e.Property.Name)
            {
                case "CreatedUserId":
                    if (e.Value == null || (long)e.Value == default || (long?)e.Value == default)
                    {
                        e.Value = user.Id;
                    }
                    break;

                case "CreatedUserName":
                    if (e.Value == null || ((string)e.Value).IsNull())
                    {
                        e.Value = user.UserName;
                    }
                    break;

            }
        }

        if (e.AuditValueType is AuditValueType.Update or AuditValueType.InsertOrUpdate)
        {
            switch (e.Property.Name)
            {
                case "ModifiedUserId":
                    e.Value = user.Id;
                    break;

                case "ModifiedUserName":
                    e.Value = user.UserName;
                    break;
            }
        }
    }

    private static void SyncStructureAfter(object? s, SyncStructureAfterEventArgs e)
    {
        if (e.Sql.NotNull())
        {
            Console.WriteLine("sync structure sql:\n" + e.Sql);
        }
    }

    /// <summary>
    /// 同步结构
    /// </summary>
    public static void SyncStructure(IFreeSql db, DbConfig dbConfig, string msg = null)
    {
        //打印结构比对脚本
        //var dDL = db.CodeFirst.GetComparisonDDLStatements<PermissionEntity>();
        //Console.WriteLine($"{Environment.NewLine}" + dDL);

        //打印结构同步脚本
        if (dbConfig.SyncStructureSql)
        {
            db.Aop.SyncStructureAfter += SyncStructureAfter;
        }

        // 同步结构
        var dbType = dbConfig.DbType.ToString();
        Console.WriteLine($"{Environment.NewLine}{(msg.NotNull() ? msg : $"sync {dbType} structure")} started");

        //获得指定程序集表实体
        var entityTypes = GetEntityTypes(dbConfig.AssemblyNames);
        db.CodeFirst.SyncStructure(entityTypes);

        if (dbConfig.SyncStructureSql)
        {
            db.Aop.SyncStructureAfter -= SyncStructureAfter;
        }

        Console.WriteLine($"{(msg.NotNull() ? msg : $"sync {dbType} structure")} succeed");
    }

    private static void SyncDataCurdBefore(object? s, CurdBeforeEventArgs e)
    {
        if (e.Sql.NotNull())
        {
            Console.WriteLine($"{e.Sql}{Environment.NewLine}");
        }
    }

    /// <summary>
    /// 同步数据
    /// </summary>
    /// <param name="db"></param>
    /// <param name="dbConfig"></param>
    /// <param name="appConfig"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static async Task SyncDataAsync(
        IFreeSql db, 
        DbConfig dbConfig = null)
    {
        try
        {
            Console.WriteLine($"{Environment.NewLine}sync data started");

            if (dbConfig.AssemblyNames?.Length > 0)
            {
                var user = dbConfig.SyncDataUser;

                // 同步数据审计方法
                void SyncDataAuditValue(object s, AuditValueEventArgs e)
                {
                    if (e.Property.GetCustomAttribute<ServerTimeAttribute>(false) != null
                           && (e.Column.CsType == typeof(DateTime) || e.Column.CsType == typeof(DateTime?))
                           && (e.Value == null || (DateTime)e.Value == default || (DateTime?)e.Value == default))
                    {
                        e.Value = DateTime.Now.Subtract(TimeOffset);
                    }

                    if (e.Column.CsType == typeof(long)
                    && e.Property.GetCustomAttribute<SnowflakeAttribute>(false) != null
                    && (e.Value == null || (long)e.Value == default || (long?)e.Value == default))
                    {
                        e.Value = YitIdHelper.NextId();
                    }

                    if (user == null || user.Id <= 0)
                    {
                        return;
                    }

                    if (e.AuditValueType is AuditValueType.Insert or AuditValueType.InsertOrUpdate)
                    {
                        switch (e.Property.Name)
                        {
                            case "CreatedUserId":
                                if (e.Value == null || (long)e.Value == default || (long?)e.Value == default)
                                {
                                    e.Value = user.Id;
                                }
                                break;

                            case "CreatedUserName":
                                if (e.Value == null || ((string)e.Value).IsNull())
                                {
                                    e.Value = user.UserName;
                                }
                                break;
                        }
                    }

                    if (e.AuditValueType is AuditValueType.Update or AuditValueType.InsertOrUpdate)
                    {
                        switch (e.Property.Name)
                        {
                            case "ModifiedUserId":
                                e.Value = user.Id;
                                break;

                            case "ModifiedUserName":
                                e.Value = user.UserName;
                                break;
                        }
                    }
                }

                db.Aop.AuditValue += SyncDataAuditValue;

                if (dbConfig.SyncDataCurd)
                {
                    db.Aop.CurdBefore += SyncDataCurdBefore;
                }

                Assembly[] assemblies = AssemblyHelper.GetAssemblyList(dbConfig.AssemblyNames);

                List<ISyncData> syncDatas = assemblies.Select(assembly => assembly.GetTypes()
                .Where(x => typeof(ISyncData).GetTypeInfo().IsAssignableFrom(x.GetTypeInfo()) && x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract))
                .SelectMany(registerTypes => registerTypes.Select(registerType => (ISyncData)Activator.CreateInstance(registerType))).ToList();

                foreach (ISyncData syncData in syncDatas)
                {
                    await syncData.SyncDataAsync(db, dbConfig);
                }

                if (dbConfig.SyncDataCurd)
                {
                    db.Aop.CurdBefore -= SyncDataCurdBefore;
                }

                db.Aop.AuditValue -= SyncDataAuditValue;
            }

            Console.WriteLine($"sync data succeed{Environment.NewLine}");
        }
        catch (Exception ex)
        {
            throw new Exception($"sync data failed.\n{ex.Message}");
        }
    }

    /// <summary>
    /// 生成数据
    /// </summary>
    /// <param name="db"></param>
    /// <param name="appConfig"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static async Task GenerateDataAsync(IFreeSql db, string[] assemblyNames, DbConfig dbConfig = null)
    {
        try
        {
            Console.WriteLine($"{Environment.NewLine}generate data started");

            if (assemblyNames?.Length > 0)
            {
                Assembly[] assemblies = AssemblyHelper.GetAssemblyList(assemblyNames);

                List<IGenerateData> generateDatas = assemblies.Select(assembly => assembly.GetTypes()
                .Where(x => typeof(IGenerateData).GetTypeInfo().IsAssignableFrom(x.GetTypeInfo()) && x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract))
                .SelectMany(registerTypes => registerTypes.Select(registerType => (IGenerateData)Activator.CreateInstance(registerType))).ToList();

                foreach (IGenerateData generateData in generateDatas)
                {
                    await generateData.GenerateDataAsync(db);
                }
            }

            Console.WriteLine($"generate data succeed{Environment.NewLine}");
        }
        catch (Exception ex)
        {
            throw new Exception($"generate data failed。\n{ex.Message}{Environment.NewLine}");
        }
    }

    /// <summary>
    /// 注册数据库
    /// </summary>
    /// <param name="freeSqlCloud"></param>
    /// <param name="user"></param>
    /// <param name="dbConfig"></param>
    /// <param name="appConfig"></param>
    /// <param name="hostAppOptions"></param>
    public static IFreeSql<T> RegisterDb<T>(
        IUser user, DbConfig dbConfig)
    {
        //创建数据库
        if (dbConfig.CreateDb)
        {
            CreateDatabaseAsync(dbConfig.DbType, dbConfig.CreateDbSql, dbConfig.CreateDbConnectionString).Wait();
        }

        var provider = dbConfig.ProviderType != null ? Type.GetType(dbConfig.ProviderType) : null;
        var freeSqlBuilder = new FreeSqlBuilder()
                .UseConnectionString(dbConfig.DbType, dbConfig.ConnectionString, provider)
                .UseAutoSyncStructure(false)
                .UseLazyLoading(false)
                .UseNoneCommandParameter(true);


        #region 监听所有命令

        if (dbConfig.MonitorCommand)
        {
            freeSqlBuilder.UseMonitorCommand(cmd => { }, (cmd, traceLog) =>
            {
                //Console.WriteLine($"{cmd.CommandText}\n{traceLog}{Environment.NewLine}");
                Console.WriteLine($"{cmd.CommandText}{Environment.NewLine}");
            });
        }

        #endregion 监听所有命令


        var fsql = freeSqlBuilder.Build<T>();

        //生成数据
        if (dbConfig.GenerateData && !dbConfig.CreateDb && !dbConfig.SyncData)
        {
            GenerateDataAsync(fsql, dbConfig.AssemblyNames, dbConfig).Wait();
        }

        #region 初始化数据库

        if (dbConfig.DbType == DataType.Oracle)
        {
            fsql.CodeFirst.IsSyncStructureToUpper = true;
        }

        //同步结构
        if (dbConfig.SyncStructure)
        {
            SyncStructure(fsql, dbConfig);
        }

        #region 审计数据

        //计算服务器时间
        var serverTime = fsql.Ado.QuerySingle(() => DateTime.UtcNow);
        var timeOffset = DateTime.UtcNow.Subtract(serverTime);
        TimeOffset = timeOffset;
        fsql.Aop.AuditValue += (s, e) =>
        {
            AuditValue(e, timeOffset, user);
        };

        #endregion 审计数据

        //同步数据
        if (dbConfig.SyncData)
        {
            SyncDataAsync(fsql, dbConfig).Wait();
        }

        #endregion 初始化数据库

        ////软删除过滤器
        //fsql.GlobalFilter.ApplyOnly<IDelete>(FilterNames.Delete, a => a.IsDeleted == false);



        //#region 监听Curd操作

        //if (dbConfig.Curd)
        //{
        //    fsql.Aop.CurdBefore += (s, e) =>
        //    {
        //        if (appConfig.MiniProfiler)
        //        {
        //            MiniProfiler.Current.CustomTiming("CurdBefore", e.Sql);
        //        }
        //        Console.WriteLine($"{e.Sql}{Environment.NewLine}");
        //    };
        //    fsql.Aop.CurdAfter += (s, e) =>
        //    {
        //        if (appConfig.MiniProfiler)
        //        {
        //            MiniProfiler.Current.CustomTiming("CurdAfter", $"{e.ElapsedMilliseconds}");
        //        }
        //    };
        //}

        //#endregion 监听Curd操作

        return fsql;
    }
}
