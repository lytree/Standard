﻿using Host.Shared;
using Host.Shared.Startup;

new HostApp(new HostAppOptions
{
	//配置FreeSql
	ConfigureFreeSql = (freeSql, dbConfig) =>
	{
		if (dbConfig.Key == DbKeys.AppDb)
		{
			freeSql.SyncSchedulerStructure(dbConfig, (fsql) =>
			{
				fsql.CodeFirst
				.ConfigEntity<TaskInfo>(a =>
				{
					a.Name("app_task");
				})
				.ConfigEntity<TaskLog>(a =>
				{
					a.Name("app_task_log");
				});
			});
		}
	},

	//配置后置服务
	ConfigurePostServices = context =>
	{
		//context.Services.AddTiDb(context);

		//添加cap事件总线
		var appConfig = ConfigHelper.Get<AppConfig>("appconfig", context.Environment.EnvironmentName);
		Assembly[] assemblies = AssemblyHelper.GetAssemblyList(appConfig.AssemblyNames);

		//var dbConfig = ConfigHelper.Get<DbConfig>("dbconfig", context.Environment.EnvironmentName);
		//var rabbitMQ = context.Configuration.GetSection("CAP:RabbitMq").Get<RabbitMQOptions>();
		context.Services.AddCap(config =>
		{
			config.UseInMemoryStorage();
			config.UseInMemoryMessageQueue();

			//<PackageReference Include="DotNetCore.CAP.MySql" Version="7.1.1" />
			//<PackageReference Include="DotNetCore.CAP.RabbitMQ" Version="7.1.1" />

			//config.UseMySql(dbConfig.ConnectionString);
			//config.UseRabbitMQ(mqConfig => {
			//    mqConfig.HostName = rabbitMQ.HostName;
			//    mqConfig.Port = rabbitMQ.Port;
			//    mqConfig.UserName = rabbitMQ.UserName;
			//    mqConfig.Password = rabbitMQ.Password;
			//    mqConfig.ExchangeName = rabbitMQ.ExchangeName;
			//});
			config.UseDashboard();
		}).AddSubscriberAssembly(assemblies);

		//添加任务调度
		context.Services.AddTaskScheduler(DbKeys.AppDb, options =>
		{
			options.ConfigureFreeSql = freeSql =>
			{
				freeSql.CodeFirst
				.ConfigEntity<TaskInfo>(a =>
				{
					a.Name("app_task");
				})
				.ConfigEntity<TaskLog>(a =>
				{
					a.Name("app_task_log");
				});
			};

			//模块任务处理器
			options.TaskHandler = new CloudTaskHandler(options.FreeSqlCloud, DbKeys.AppDb);
		});
	},

	//配置Autofac容器
	ConfigureAutofacContainer = (builder, context) =>
	{

	},

	//配置Mvc
	ConfigureMvcBuilder = (builder, context) =>
	{
	},

	//配置后置中间件
	ConfigurePostMiddleware = context =>
	{
		var app = context.App;
		var env = app.Environment;
		var appConfig = app.Services.GetService<AppConfig>();

		#region 新版Api文档
		if (env.IsDevelopment() || appConfig.ApiUI.Enable)
		{
			app.UseApiUI(options =>
			{
				options.RoutePrefix = appConfig.ApiUI.RoutePrefix;
				var routePath = options.RoutePrefix.NotNull() ? $"{options.RoutePrefix}/" : "";
				appConfig.Swagger.Projects?.ForEach(project =>
				{
					options.SwaggerEndpoint($"/{routePath}swagger/{project.Code.ToLower()}/swagger.json", project.Name);
				});
			});
		}
		#endregion

		//使用任务调度
		app.UseTaskScheduler();
	}
}).Run(args);

#if DEBUG
public partial class Program { }
#endif