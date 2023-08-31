using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Service.Admin;

public static class ServiceBase
{
	public static IServiceCollection Services;

	public static IServiceProvider ServiceProvider;

	public static IWebHostEnvironment WebHostEnvironment;

	public static IHostEnvironment HostEnvironment;

	public static IConfiguration Configuration;

	/// <summary>
	/// 应用是否运行
	/// </summary>
	public static bool IsRun { get; set; }

	public static void ConfigureApplication(this WebApplicationBuilder webApplicationBuilder)
	{
		HostEnvironment = webApplicationBuilder.Environment;
		WebHostEnvironment = webApplicationBuilder.Environment;
		Services = webApplicationBuilder.Services;
		Configuration = webApplicationBuilder.Configuration;
	}

	public static void ConfigureApplication(this WebApplication app)
	{
		ServiceProvider = app.Services;
	}
}
