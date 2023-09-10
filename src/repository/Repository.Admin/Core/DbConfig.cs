﻿using FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Admin.Core;

public class DbConfig
{
    /// <summary>
    /// 数据库注册键
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// 程序集名称
    /// </summary>
    public string[] AssemblyNames { get; set; }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public DataType DbType { get; set; } = DataType.Sqlite;

    /// <summary>
    /// 数据库字符串
    /// </summary>
    public string ConnectionString { get; set; } = "Data Source=|DataDirectory|\\admindb.db; Pooling=true;Min Pool Size=1";

    /// <summary>
    /// 指定程序集
    /// </summary>
    public string ProviderType { get; set; }

    /// <summary>
    /// 生成数据
    /// </summary>
    public bool GenerateData { get; set; } = false;

    /// <summary>
    /// 同步结构
    /// </summary>
    public bool SyncStructure { get; set; } = false;

    /// <summary>
    /// 同步结构脚本
    /// </summary>
    public bool SyncStructureSql { get; set; } = false;

    /// <summary>
    /// 同步数据
    /// </summary>
    public bool SyncData { get; set; } = false;

    /// <summary>
    /// 同步数据监听Curd操作
    /// </summary>
    public bool SyncDataCurd { get; set; } = false;

    /// <summary>
    /// 同步更新数据
    /// </summary>
    public bool SysUpdateData { get; set; } = false;

    /// <summary>
    /// 同步数据地址
    /// </summary>
    public string SyncDataPath { get; set; } = "InitData/Admin";

    /// <summary>
    /// 同步数据包含表列表
    /// </summary>
    public string[] SyncDataIncludeTables { get; set; }

    /// <summary>
    /// 同步数据排除表列表
    /// </summary>
    public string[] SyncDataExcludeTables { get; set; }

    /// <summary>
    /// 同步数据操作用户
    /// </summary>
    public SyncDataUser SyncDataUser { get; set; } = new SyncDataUser { Id = 161223411986501, UserName = "admin" };

    /// <summary>
    /// 建库
    /// </summary>
    public bool CreateDb { get; set; } = false;

    /// <summary>
    /// 建库连接字符串
    /// </summary>
    public string CreateDbConnectionString { get; set; }

    /// <summary>
    /// 建库脚本
    /// </summary>
    public string CreateDbSql { get; set; }

    /// <summary>
    /// 监听所有操作
    /// </summary>
    public bool MonitorCommand { get; set; } = false;

    /// <summary>
    /// 监听Curd操作
    /// </summary>
    public bool Curd { get; set; } = false;


}
/// <summary>
/// 同步数据操作用户
/// </summary>
public class SyncDataUser
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    public string UserName { get; set; }

}