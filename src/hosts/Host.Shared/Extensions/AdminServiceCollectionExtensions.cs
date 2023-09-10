using Host.Shared.Config;
using Host.Shared.Startup;
using Microsoft.Extensions.DependencyInjection;
using Repository.Admin;
using Repository.Admin.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Host.Shared.Extensions;

public static class AdminServiceCollectionExtensions
{
    /// <summary>
    /// 添加数据库
    /// </summary>
    /// <param name="services"></param>
    /// <param name="env"></param>
    /// <returns></returns>
    public static void AddAdminDb(this IServiceCollection services, IHostEnvironment env)
    {
        var dbConfig = ConfigHelper.Get<Config.DbConfig>("dbconfig", env.EnvironmentName);
        var appConfig = ConfigHelper.Get<AppConfig>("appconfig", env.EnvironmentName);
        var user = services.BuildServiceProvider().GetService<Repository.Admin.Core.IUser>();


        services.AddSingleton<IFreeSql<AdminDb>>(DbHelper.RegisterDb<AdminDb>(user, dbConfig.AdminDb));
    }

    /// <summary>
    /// 添加TiDb数据库
    /// </summary>
    /// <param name="_"></param>
    /// <param name="context"></param>
    /// <param name="version">版本</param>
    public static void AddTiDb(this IServiceCollection _, HostAppContext context, string version = "8.0")
    {
        var dbConfig = ConfigHelper.Get<Config.DbConfig>("dbconfig", context.Environment.EnvironmentName);
        var _dicMySqlVersion = typeof(FreeSqlGlobalExtensions).GetField("_dicMySqlVersion", BindingFlags.NonPublic | BindingFlags.Static);
        var dicMySqlVersion = new ConcurrentDictionary<string, string>();
        dicMySqlVersion[dbConfig.AdminDb.ConnectionString] = version;
        _dicMySqlVersion.SetValue(new ConcurrentDictionary<string, string>(), dicMySqlVersion);
    }
}
