using Host.Shared;
using Host.Shared.Startup;
using Infrastructure;
using Infrastructure.Service;
using Plugin.ApiUI;
using System.Reflection;

new HostApp(new HostAppOptions
{

    //配置后置服务
    ConfigurePostServices = context =>
    {
        ////context.Services.AddTiDb(context);

        ////添加cap事件总线
        //var appConfig = ConfigHelper.Get<AppConfig>("appconfig", context.Environment.EnvironmentName);
        //Assembly[] assemblies = AssemblyHelper.GetAssemblyList(appConfig.AssemblyNames);

        ////var dbConfig = ConfigHelper.Get<AdminDbConfig>("dbconfig", context.Environment.EnvironmentName);
        ////var rabbitMQ = context.Configuration.GetSection("CAP:RabbitMq").Get<RabbitMQOptions>();
        //context.Services.AddCap(config =>
        //{
        //	config.UseInMemoryStorage();
        //	config.UseInMemoryMessageQueue();

        //	//<PackageReference Include="DotNetCore.CAP.MySql" Version="7.1.1" />
        //	//<PackageReference Include="DotNetCore.CAP.RabbitMQ" Version="7.1.1" />

        //	//config.UseMySql(dbConfig.ConnectionString);
        //	//config.UseRabbitMQ(mqConfig => {
        //	//    mqConfig.HostName = rabbitMQ.HostName;
        //	//    mqConfig.Port = rabbitMQ.Port;
        //	//    mqConfig.UserName = rabbitMQ.UserName;
        //	//    mqConfig.Password = rabbitMQ.Password;
        //	//    mqConfig.ExchangeName = rabbitMQ.ExchangeName;
        //	//});
        //	config.UseDashboard();
        //}).AddSubscriberAssembly(assemblies);

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
        var apiConfig = app.Services.GetService<ApiConfig>();

        #region 新版Api文档
        if (env.IsDevelopment() || apiConfig.ApiUI.Enable)
        {
            app.UseApiUI(options =>
            {
                options.RoutePrefix = apiConfig.ApiUI.RoutePrefix;
                var routePath = options.RoutePrefix != null ? $"{options.RoutePrefix}/" : "";
                apiConfig.Swagger.Projects?.ForEach(project =>
                {
                    options.SwaggerEndpoint($"/{routePath}swagger/{project.Code.ToLower()}/swagger.json", project.Name);
                });
            });
        }
        #endregion

        ////使用任务调度
        //app.UseTaskScheduler();
    }
}).Run(args);

#if DEBUG
public partial class Program { }
#endif