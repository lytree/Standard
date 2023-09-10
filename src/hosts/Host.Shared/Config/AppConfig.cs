using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Host.Shared.Config;

public partial class AppConfig
{
    public AppType AppType { get; set; } = AppType.Controllers;

    /// <summary>
    /// Api地址，默认 http://*:8000
    /// </summary>
    public string[] Urls { get; set; }

    /// <summary>
    /// 跨域地址，默认 http://*:9000
    /// </summary>
    public string[] CorUrls { get; set; }

    /// <summary>
    /// 程序集名称
    /// </summary>
    public string[] AssemblyNames { get; set; }

    /// <summary>
    /// 租户类型
    /// </summary>
    public bool Tenant { get; set; } = false;

    /// <summary>
    /// 分布式事务唯一标识
    /// </summary>
    public string DistributeKey { get; set; }

    /// <summary>
    /// Swagger文档
    /// </summary>
    public SwaggerConfig Swagger { get; set; } = new SwaggerConfig();

    /// <summary>
    /// 新版Api文档
    /// </summary>
    public ApiUIConfig ApiUI { get; set; } = new ApiUIConfig();

    /// <summary>
    /// MiniProfiler性能分析器
    /// </summary>
    public bool MiniProfiler { get; set; } = false;

    /// <summary>
    /// Aop配置
    /// </summary>
    public AopConfig Aop { get; set; } = new AopConfig();

    /// <summary>
    /// 日志配置
    /// </summary>
    public LogConfig Log { get; set; } = new LogConfig();

    /// <summary>
    /// 验证配置
    /// </summary>
    public ValidateConfig Validate { get; set; } = new ValidateConfig();

    /// <summary>
    /// 限流
    /// </summary>
    public bool RateLimit { get; set; } = false;

    /// <summary>
    /// 验证码配置
    /// </summary>
    public VarifyCodeConfig VarifyCode { get; set; } = new VarifyCodeConfig();

    /// <summary>
    /// 默认密码
    /// </summary>
    public string DefaultPassword { get; set; } = "111111";

    /// <summary>
    /// 动态Api配置
    /// </summary>
    public DynamicApiConfig DynamicApi { get; set; } = new DynamicApiConfig();

    /// <summary>
    /// 实现标准标识密码哈希
    /// </summary>
    public bool PasswordHasher { get; set; } = false;

    /// <summary>
    /// 最大请求大小
    /// </summary>
    public long MaxRequestBodySize { get; set; } = 104857600;

    /// <summary>
    /// 健康检查配置
    /// </summary>
    public HealthChecksConfig HealthChecks { get; set; } = new HealthChecksConfig();
}
/// <summary>
/// Aop配置
/// </summary>
public class AopConfig
{
    /// <summary>
    /// 事务
    /// </summary>
    public bool Transaction { get; set; } = true;
}

/// <summary>
/// 日志配置
/// </summary>
public class LogConfig
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public bool Operation { get; set; } = true;
}

/// <summary>
/// 验证配置
/// </summary>
public class ValidateConfig
{
    /// <summary>
    /// 登录
    /// </summary>
    public bool Login { get; set; } = true;

    /// <summary>
    /// 接口权限
    /// </summary>
    public bool Permission { get; set; } = true;

    /// <summary>
    /// 数据权限
    /// </summary>
    public bool DataPermission { get; set; } = true;
}

/// <summary>
/// 验证码配置
/// </summary>
public class VarifyCodeConfig
{
    /// <summary>
    /// 启用
    /// </summary>
    public bool Enable { get; set; } = true;

    /// <summary>
    /// 操作日志
    /// </summary>
    public string[] Fonts { get; set; }// = new[] { "Times New Roman", "Verdana", "Arial", "Gungsuh", "Impact" };
}
/// <summary>
/// 动态api配置
/// </summary>
public class DynamicApiConfig
{
    /// <summary>
    /// 结果格式化
    /// </summary>
    public bool FormatResult { get; set; } = true;
}

/// <summary>
/// 健康检查配置
/// </summary>
public class HealthChecksConfig
{
    /// <summary>
    /// 启用
    /// </summary>
    public bool Enable { get; set; } = true;

    /// <summary>
    /// 访问路径
    /// </summary>
    public string Path { get; set; } = "/health";
}

/// <summary>
/// 应用程序类型
/// </summary>
public enum AppType
{
    Controllers,
    ControllersWithViews,
    MVC
}