﻿using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Startup
{
	/// <summary>
	/// 宿主应用配置
	/// </summary>
	public class HostAppOptions
	{
		/// <summary>
		/// 配置前置应用程序构建器
		/// </summary>
		public Action<WebApplicationBuilder> ConfigurePreWebApplicationBuilder { get; set; }

		/// <summary>
		/// 配置应用程序构建器
		/// </summary>
		public Action<WebApplicationBuilder> ConfigureWebApplicationBuilder { get; set; }

		/// <summary>
		/// 配置前置服务
		/// </summary>
		public Action<HostAppContext> ConfigurePreServices { get; set; }

		/// <summary>
		/// 配置服务
		/// </summary>
		public Action<HostAppContext> ConfigureServices { get; set; }

		/// <summary>
		/// 配置后置服务
		/// </summary>
		public Action<HostAppContext> ConfigurePostServices { get; set; }

		/// <summary>
		/// 配置mvc构建器
		/// </summary>
		public Action<IMvcBuilder, HostAppContext> ConfigureMvcBuilder { get; set; }

		/// <summary>
		/// 配置Autofac容器
		/// </summary>
		public Action<ContainerBuilder, HostAppContext> ConfigureAutofacContainer { get; set; }

		/// <summary>
		/// 配置前置中间件
		/// </summary>
		public Action<HostAppMiddlewareContext> ConfigurePreMiddleware { get; set; }

		/// <summary>
		/// 配置中间件
		/// </summary>
		public Action<HostAppMiddlewareContext> ConfigureMiddleware { get; set; }

		/// <summary>
		/// 配置后置中间件
		/// </summary>
		public Action<HostAppMiddlewareContext> ConfigurePostMiddleware { get; set; }

		/// <summary>
		/// 配置FreeSql构建器
		/// </summary>
		public Action<FreeSqlBuilder, DbConfig> ConfigureFreeSqlBuilder { get; set; }

		/// <summary>
		/// 配置FreeSql
		/// </summary>
		public Action<IFreeSql, DbConfig> ConfigureFreeSql { get; set; }

		/// <summary>
		/// 配置动态Api
		/// </summary>
		public Action<DynamicApiOptions> ConfigureDynamicApi { get; set; }

		/// <summary>
		/// 配置雪花漂移算法
		/// </summary>
		public Action<IdGeneratorOptions> ConfigureIdGenerator { get; set; }

		/// <summary>
		/// 自定义数据库初始化
		/// </summary>
		public bool CustomInitDb { get; set; } = false;

	}
}
