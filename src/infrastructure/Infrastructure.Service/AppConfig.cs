﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Service;

public partial class AppConfig
{
	/// <summary>
	/// Api地址，默认 http://*:8000
	/// </summary>
	public string[] Urls { get; set; }

	/// <summary>
	/// 跨域地址，默认 http://*:9000
	/// </summary>
	public string[] CorUrls { get; set; }

	/// <summary>
	/// MiniProfiler性能分析器
	/// </summary>
	public bool MiniProfiler { get; set; } = false;
	/// <summary>
	/// Swagger文档
	/// </summary>
	public SwaggerConfig Swagger { get; set; } = new SwaggerConfig();
	/// <summary>
	/// 最大请求大小
	/// </summary>
	public long MaxRequestBodySize { get; set; } = 104857600;
	/// <summary>
	/// 默认密码
	/// </summary>
	public string DefaultPassword { get; set; } = "111111";

	/// <summary>
	/// 实现标准标识密码哈希
	/// </summary>
	public bool PasswordHasher { get; set; } = false;
	
	/// <summary>
	/// 限流
	/// </summary>
	public bool RateLimit { get; set; } = false;
	/// <summary>
	/// 验证码配置
	/// </summary>
	public VarifyCodeConfig VarifyCode { get; set; } = new VarifyCodeConfig();
	/// <summary>
	/// 程序集名称
	/// </summary>
	public string[] AssemblyNames { get; set; }

	/// <summary>
	/// 健康检查配置
	/// </summary>
	public HealthChecksConfig HealthChecks { get; set; } = new HealthChecksConfig();
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
/// Swagger配置
/// </summary>
public class SwaggerConfig
{
	/// <summary>
	/// 启用
	/// </summary>
	public bool Enable { get; set; } = false;

	/// <summary>
	/// 启用枚举架构过滤器
	/// </summary>
	public bool EnableEnumSchemaFilter { get; set; } = true;

	/// <summary>
	/// 启用接口排序文档过滤器
	/// </summary>
	public bool EnableOrderTagsDocumentFilter { get; set; } = true;

	/// <summary>
	/// 启用枚举属性名
	/// </summary>
	public bool EnableJsonStringEnumConverter { get; set; } = false;

	/// <summary>
	/// 启用SchemaId命名空间
	/// </summary>
	public bool EnableSchemaIdNamespace { get; set; } = false;

	/// <summary>
	/// 程序集列表
	/// </summary>
	public string[] AssemblyNameList { get; set; }

	private string _RoutePrefix = "swagger";
	/// <summary>
	/// 访问地址
	/// </summary>
	public string RoutePrefix { get => Regex.Replace(_RoutePrefix, "^\\/+|\\/+$", ""); set => _RoutePrefix = value; }

	/// <summary>
	/// 地址
	/// </summary>
	public string Url { get; set; }

	/// <summary>
	/// 项目列表
	/// </summary>
	public List<ProjectConfig> Projects { get; set; }
}
/// <summary>
/// 项目配置
/// </summary>
public class ProjectConfig
{
	/// <summary>
	/// 名称
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// 编码
	/// </summary>
	public string Code { get; set; }

	/// <summary>
	/// 版本
	/// </summary>
	public string Version { get; set; }

	/// <summary>
	/// 描述
	/// </summary>
	public string Description { get; set; }
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