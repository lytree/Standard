using Repository.Admin.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Service.Admin
{
	internal static class AdminInfo
	{
		static AdminInfo()
		{
			
		}


		/// <summary>
		/// 服务提供程序
		/// </summary>
		public static IServiceProvider? ServiceProvider => ServiceBase.IsRun ? ServiceBase.ServiceProvider : null;

		/// <summary>
		/// Web主机环境
		/// </summary>
		public static IWebHostEnvironment WebHostEnvironment => ServiceBase.WebHostEnvironment;

		/// <summary>
		/// 泛型主机环境
		/// </summary>
		public static IHostEnvironment HostEnvironment => ServiceBase.HostEnvironment;

		/// <summary>
		/// 配置
		/// </summary>
		public static IConfiguration Configuration => ServiceBase.Configuration;

		/// <summary>
		/// 请求上下文
		/// </summary>
		public static HttpContext? HttpContext => ServiceProvider?.GetService<IHttpContextAccessor>()?.HttpContext;

		/// <summary>
		/// 用户
		/// </summary>
		public static IUser? User => HttpContext == null ? null : ServiceProvider?.GetService<IUser>();

		/// <summary>
		/// 日志
		/// </summary>
		public static ILogger Log => (ServiceProvider?.GetService<ILoggerFactory>() ?? NullLoggerFactory.Instance).CreateLogger(typeof(AdminInfo));

		#region Service
		/// <summary>
		/// 获得服务提供程序
		/// </summary>
		/// <param name="serviceType"></param>
		/// <param name="isBuild"></param>
		/// <returns></returns>
		/// <exception cref="ApplicationException"></exception>
		public static IServiceProvider GetServiceProvider(Type serviceType, bool isBuild = false)
		{
			if (HostEnvironment == null || ServiceProvider != null &&
				ServiceBase.Services
				.Where(u => u.ServiceType == (serviceType.IsGenericType ? serviceType.GetGenericTypeDefinition() : serviceType))
				.Any(u => u.Lifetime == ServiceLifetime.Singleton))
				return ServiceProvider;
			HttpContext httpContext = HttpContext;

			if (httpContext?.RequestServices != null)
				return httpContext.RequestServices;

			if (ServiceProvider != null)
			{
				IServiceScope scope = ServiceProvider.CreateScope();
				return scope.ServiceProvider;
			}

			if (isBuild)
			{
				throw new ApplicationException("The current is not available and must wait until the WebApplication Build is completed.");
			}

			ServiceProvider serviceProvider = ServiceBase.Services.BuildServiceProvider();

			return serviceProvider;
		}

		/// <summary>
		/// 获得请求生存周期的服务
		/// </summary>
		/// <typeparam name="TService"></typeparam>
		/// <param name="isBuild"></param>
		/// <returns></returns>
		public static TService GetService<TService>(bool isBuild = true) where TService : class =>
			GetService(typeof(TService), null, isBuild) as TService;

		/// <summary>
		/// 获得请求生存周期的服务
		/// </summary>
		/// <typeparam name="TService"></typeparam>
		/// <param name="serviceProvider"></param>
		/// <param name="isBuild"></param>
		/// <returns></returns>
		public static TService GetService<TService>(IServiceProvider serviceProvider, bool isBuild = true) where TService : class =>
			GetService(typeof(TService), serviceProvider, isBuild) as TService;

		/// <summary>
		/// 获得服务
		/// </summary>
		/// <param name="type"></param>
		/// <param name="serviceProvider"></param>
		/// <param name="isBuild"></param>
		/// <returns></returns>
		public static object GetService(Type type, IServiceProvider serviceProvider = null, bool isBuild = true) =>
			(serviceProvider ?? GetServiceProvider(type, isBuild)).GetService(type);

		/// <summary>
		/// 获得服务
		/// </summary>
		/// <typeparam name="TService"></typeparam>
		/// <param name="isBuild"></param>
		/// <returns></returns>
		public static TService GetRequiredService<TService>(bool isBuild = true) where TService : class =>
			GetRequiredService(typeof(TService), null, isBuild) as TService;

		/// <summary>
		/// 获取服务
		/// </summary>
		/// <typeparam name="TService"></typeparam>
		/// <param name="serviceProvider"></param>
		/// <param name="isBuild"></param>
		/// <returns></returns>
		public static TService GetRequiredService<TService>(IServiceProvider serviceProvider, bool isBuild = true) where TService : class =>
			GetRequiredService(typeof(TService), serviceProvider, isBuild) as TService;

		/// <summary>
		/// 获得服务
		/// </summary>
		/// <param name="type"></param>
		/// <param name="serviceProvider"></param>
		/// <param name="isBuild"></param>
		/// <returns></returns>
		public static object GetRequiredService(Type type, IServiceProvider serviceProvider = null, bool isBuild = true) =>
			(serviceProvider ?? GetServiceProvider(type, isBuild)).GetRequiredService(type);

		#endregion

		#region Options
		/// <summary>
		/// 获得选项
		/// </summary>
		/// <typeparam name="TOptions"></typeparam>
		/// <param name="path"></param>
		/// <returns></returns>
		public static TOptions GetOptions<TOptions>(string path) where TOptions : class, new() =>
			Configuration.GetSection(path).Get<TOptions>();

		/// <summary>
		/// 获得选项
		/// </summary>
		/// <typeparam name="TOptions"></typeparam>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public static TOptions GetOptions<TOptions>(IServiceProvider serviceProvider = null) where TOptions : class, new() =>
			GetService<IOptions<TOptions>>(serviceProvider ?? ServiceProvider, false)?.Value;

		/// <summary>
		/// 获得选项
		/// </summary>
		/// <typeparam name="TOptions"></typeparam>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public static TOptions GetOptionsMonitor<TOptions>(IServiceProvider serviceProvider = null) where TOptions : class, new() =>
			GetService<IOptionsMonitor<TOptions>>(serviceProvider ?? ServiceProvider, false)?.CurrentValue;

		/// <summary>
		/// 获得选项
		/// </summary>
		/// <typeparam name="TOptions"></typeparam>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public static TOptions GetOptionsSnapshot<TOptions>(IServiceProvider serviceProvider = null) where TOptions : class, new() =>
			GetService<IOptionsSnapshot<TOptions>>(serviceProvider, false)?.Value;
		#endregion
	}
}
