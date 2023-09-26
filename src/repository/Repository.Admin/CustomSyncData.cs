﻿using System.Threading.Tasks;
using System.Linq;
using System;
using FreeSql;
using Mapster;
using System.Collections.Generic;
using Repository.Admin.Core;
using Repository.Admin.Repository.Role;
using Repository.Admin.Repository.User;
using Repository.Admin.Repository.View;
using Repository.Admin.Repository.UserRole;
using Repository.Admin.Repository.RolePermission;
using Repository.Admin.Repository.Permission;
using Repository.Admin.Repository.DictType;
using Repository.Admin.Repository.Dict;
using Repository.Admin.Repository.Api;
using Repository.Admin.Repository.PermissionApi;

namespace Repository.Admin;
/// <summary>
/// 同步数据
/// </summary>
public class CustomSyncData : SyncData, ISyncData
{
    /// <summary>
    /// 初始化字典类型
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitDictTypeAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<DictTypeEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<DictTypeEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var sourceDataList = GetData<DictTypeEntity>(path: dbConfig.SyncDataPath);

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var sourceDataIds = sourceDataList.Select(e => e.Id).ToList();
            var dataList = await rep.Where(a => sourceDataIds.Contains(a.Id)).ToListAsync();

            //新增
            var dataIds = dataList.Select(a => a.Id).ToList();
            var insertDataList = sourceDataList.Where(a => !dataIds.Contains(a.Id));
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            //修改
            if (dbConfig.SysUpdateData)
            {
                var updateDataList = dataList.Where(a => sourceDataIds.Contains(a.Id));
                if (updateDataList.Any())
                {
                    foreach (var data in updateDataList)
                    {
                        var sourceData = sourceDataList.Where(a => a.Id == data.Id).First();
                        sourceData.Adapt(data);
                    }

                    await rep.UpdateAsync(updateDataList);
                }
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }

    /// <summary>
    /// 初始化字典
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitDictAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<DictEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<DictEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var sourceDataList = GetData<DictEntity>(path: dbConfig.SyncDataPath);

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var sourceDataIds = sourceDataList.Select(e => e.Id).ToList();
            var dataList = await rep.Where(a => sourceDataIds.Contains(a.Id)).ToListAsync();

            //新增
            var dataIds = dataList.Select(a => a.Id).ToList();
            var insertDataList = sourceDataList.Where(a => !dataIds.Contains(a.Id));
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            //修改
            if (dbConfig.SysUpdateData)
            {
                var updateDataList = dataList.Where(a => sourceDataIds.Contains(a.Id));
                if (updateDataList.Any())
                {
                    foreach (var data in updateDataList)
                    {
                        var sourceData = sourceDataList.Where(a => a.Id == data.Id).First();
                        sourceData.Adapt(data);
                    }

                    await rep.UpdateAsync(updateDataList);
                }
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }

    /// <summary>
    /// 初始化用户
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitUserAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<UserEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<UserEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var sourceDataList = GetData<UserEntity>(dbConfig.SyncDataPath);

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var sourceDataIds = sourceDataList.Select(e => e.Id).ToList();
            var dataList = await rep.Where(a => sourceDataIds.Contains(a.Id)).ToListAsync();

            //新增
            var dataIds = dataList.Select(a => a.Id).ToList();
            var insertDataList = sourceDataList.Where(a => !dataIds.Contains(a.Id));
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            //修改
            if (dbConfig.SysUpdateData)
            {
                var updateDataList = dataList.Where(a => sourceDataIds.Contains(a.Id));
                if (updateDataList.Any())
                {
                    foreach (var data in updateDataList)
                    {
                        var sourceData = sourceDataList.Where(a => a.Id == data.Id).First();
                        sourceData.Adapt(data);
                    }

                    await rep.UpdateAsync(updateDataList);
                }
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }
    /// <summary>
    /// 初始化角色
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitRoleAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<RoleEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<RoleEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var sourceDataList = GetData<RoleEntity>(dbConfig.SyncDataPath);

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var sourceDataIds = sourceDataList.Select(e => e.Id).ToList();
            var dataList = await rep.Where(a => sourceDataIds.Contains(a.Id)).ToListAsync();

            //新增
            var dataIds = dataList.Select(a => a.Id).ToList();
            var insertDataList = sourceDataList.Where(a => !dataIds.Contains(a.Id));
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            //修改
            if (dbConfig.SysUpdateData)
            {
                var updateDataList = dataList.Where(a => sourceDataIds.Contains(a.Id));
                if (updateDataList.Any())
                {
                    foreach (var data in updateDataList)
                    {
                        var sourceData = sourceDataList.Where(a => a.Id == data.Id).First();
                        sourceData.Adapt(data);
                    }

                    await rep.UpdateAsync(updateDataList);
                }
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }

    /// <summary>
    /// 初始化接口
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitApiAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<ApiEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<ApiEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var dataTree = GetData<ApiEntity>(path: dbConfig.SyncDataPath);
            var sourceDataList = dataTree.ToList().ToPlainList((a) => a.Childs).ToArray();

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var sourceDataIds = sourceDataList.Select(e => e.Id).ToList();
            var dataList = await rep.Where(a => sourceDataIds.Contains(a.Id)).ToListAsync();

            //新增
            var dataIds = dataList.Select(a => a.Id).ToList();
            var insertDataList = sourceDataList.Where(a => !dataIds.Contains(a.Id));
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            //修改
            if (dbConfig.SysUpdateData)
            {
                var updateDataList = dataList.Where(a => sourceDataIds.Contains(a.Id));
                if (updateDataList.Any())
                {
                    foreach (var data in updateDataList)
                    {
                        var sourceData = sourceDataList.Where(a => a.Id == data.Id).First();
                        sourceData.Adapt(data);
                    }

                    await rep.UpdateAsync(updateDataList);
                }
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }

    /// <summary>
    /// 初始化视图
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitViewAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<ViewEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<ViewEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var dataTree = GetData<ViewEntity>(path: dbConfig.SyncDataPath);
            var sourceDataList = dataTree.ToList().ToPlainList((a) => a.Childs).ToArray();

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var sourceDataIds = sourceDataList.Select(e => e.Id).ToList();
            var dataList = await rep.Where(a => sourceDataIds.Contains(a.Id)).ToListAsync();

            //新增
            var dataIds = dataList.Select(a => a.Id).ToList();
            var insertDataList = sourceDataList.Where(a => !dataIds.Contains(a.Id));
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            //修改
            if (dbConfig.SysUpdateData)
            {
                var updateDataList = dataList.Where(a => sourceDataIds.Contains(a.Id));
                if (updateDataList.Any())
                {
                    foreach (var data in updateDataList)
                    {
                        var sourceData = sourceDataList.Where(a => a.Id == data.Id).First();
                        sourceData.Adapt(data);
                    }

                    await rep.UpdateAsync(updateDataList);
                }
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }

    /// <summary>
    /// 初始化权限
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitPermissionAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<PermissionEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<PermissionEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var dataTree = GetData<PermissionEntity>(path: dbConfig.SyncDataPath);
            var sourceDataList = dataTree.ToList().ToPlainList((a) => a.Childs).ToArray();

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var sourceDataIds = sourceDataList.Select(e => e.Id).ToList();
            var dataList = await rep.Where(a => sourceDataIds.Contains(a.Id)).ToListAsync();

            //新增
            var dataIds = dataList.Select(a => a.Id).ToList();
            var insertDataList = sourceDataList.Where(a => !dataIds.Contains(a.Id));
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            //修改
            if (dbConfig.SysUpdateData)
            {
                var updateDataList = dataList.Where(a => sourceDataIds.Contains(a.Id));
                if (updateDataList.Any())
                {
                    foreach (var data in updateDataList)
                    {
                        var sourceData = sourceDataList.Where(a => a.Id == data.Id).First();
                        sourceData.Adapt(data);
                    }

                    await rep.UpdateAsync(updateDataList);
                }
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }

    /// <summary>
    /// 初始化权限接口
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitPermissionApiAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<PermissionApiEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<PermissionApiEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var sourceDataList = GetData<PermissionApiEntity>(path: dbConfig.SyncDataPath);

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var dataList = await rep.Where(a => rep.Select.WithMemory(sourceDataList).Where(b => b.PermissionId == a.PermissionId && b.ApiId == a.ApiId).Any()).ToListAsync();

            //新增
            var insertDataList = sourceDataList.Where(a => !dataList.Where(b => a.PermissionId == b.PermissionId && a.ApiId == b.ApiId).Any()).ToList();
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }

    /// <summary>
    /// 用户角色记录
    /// </summary>
    /// <param name="UserId"></param>
    /// <param name="RoleId"></param>
    record UserRoleRecord(long UserId, long RoleId);

    /// <summary>
    /// 初始化用户角色
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitUserRoleAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<UserRoleEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<UserRoleEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var sourceDataList = GetData<UserRoleEntity>(path: dbConfig.SyncDataPath);

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var userRoleRecordList = sourceDataList.Adapt<List<UserRoleRecord>>();
            var dataList = await rep.Where(a => rep.Orm.Select<UserRoleRecord>().WithMemory(userRoleRecordList).Where(b => b.UserId == a.UserId && b.RoleId == a.RoleId).Any()).ToListAsync();

            //新增
            var insertDataList = sourceDataList.Where(a => !dataList.Where(b => a.UserId == b.UserId && a.RoleId == b.RoleId).Any()).ToList();
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }


    /// <summary>
    /// 角色权限记录
    /// </summary>
    /// <param name="RoleId"></param>
    /// <param name="PermissionId"></param>
    record RolePermissionRecord(long RoleId, long PermissionId);

    /// <summary>
    /// 初始化角色权限
    /// </summary>
    /// <param name="db"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="dbConfig"></param>
    /// <returns></returns>
    private async Task InitRolePermissionAsync(IFreeSql db, IRepositoryUnitOfWork unitOfWork, AdminDbConfig dbConfig)
    {
        var tableName = GetTableName<RolePermissionEntity>();
        try
        {
            if (!IsSyncData(tableName, dbConfig))
            {
                return;
            }

            var rep = db.GetRepository<RolePermissionEntity>();
            rep.UnitOfWork = unitOfWork;

            //数据列表
            var sourceDataList = GetData<RolePermissionEntity>(path: dbConfig.SyncDataPath);

            if (!(sourceDataList?.Length > 0))
            {
                Console.WriteLine($"table: {tableName} import data []");
                return;
            }

            //查询
            var rolePermissionRecordList = sourceDataList.Adapt<List<RolePermissionRecord>>();
            var dataList = await rep.Where(a => rep.Orm.Select<RolePermissionRecord>().WithMemory(rolePermissionRecordList).Where(b => b.RoleId == a.RoleId && b.PermissionId == a.PermissionId).Any()).ToListAsync();

            //新增
            var insertDataList = sourceDataList.Where(a => !dataList.Where(b => a.RoleId == b.RoleId && a.PermissionId == b.PermissionId).Any()).ToList();
            if (insertDataList.Any())
            {
                await rep.InsertAsync(insertDataList);
            }

            Console.WriteLine($"table: {tableName} sync data succeed");
        }
        catch (Exception ex)
        {
            var msg = $"table: {tableName} sync data failed.\n{ex.Message}";
            Console.WriteLine(msg);
            throw new Exception(msg);
        }
    }

    /// <summary>
    /// 同步数据
    /// </summary>
    /// <param name="db"></param>
    /// <param name="dbConfig"></param>
    /// <param name="appConfig"></param>
    /// <returns></returns>
    public virtual async Task SyncDataAsync(IFreeSql db, DbConfig? dbConfig = null)
    {
        using var unitOfWork = db.CreateUnitOfWork();

        try
        {
            if (dbConfig is AdminDbConfig config)
            {
                await InitDictTypeAsync(db, unitOfWork, config);
                await InitDictAsync(db, unitOfWork, config);
                await InitUserAsync(db, unitOfWork, config);

                await InitRoleAsync(db, unitOfWork, config);
                await InitApiAsync(db, unitOfWork, config);
                await InitViewAsync(db, unitOfWork, config);
                await InitPermissionAsync(db, unitOfWork, config);
                await InitPermissionApiAsync(db, unitOfWork, config);
                await InitUserRoleAsync(db, unitOfWork, config);
                await InitRolePermissionAsync(db, unitOfWork, config);
            }


            unitOfWork.Commit();
        }
        catch (Exception)
        {
            unitOfWork.Rollback();
            throw;
        }
    }
}
