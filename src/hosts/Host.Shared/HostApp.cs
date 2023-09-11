﻿using AspNetCoreRateLimit;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using Host.Shared.Filters;
using Host.Shared.Startup;
using Infrastructure;
using Infrastructure.Cache.Cache;
using Infrastructure.Core;
using Repository.Admin.Core;
using Infrastructure.Service;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Plugin.ApiUI;
using Plugin.DynamicApi.Attributes;
using Plugin.DynamicApi;
using Serilog;
using Service.Admin;
using Service.Admin.Captcha;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Yitter.IdGenerator;
using Infrastructure.JsonConverter;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Service.Admin.Auth;
using Host.Shared.Extensions;
using System.Text.Json.Serialization;
using Service.Admin.OprationLog;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Text.Json;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Host.Shared;

public class HostApp
{
    readonly HostAppOptions _hostAppOptions;

    public HostApp()
    {
    }

    public HostApp(HostAppOptions hostAppOptions)
    {
        _hostAppOptions = hostAppOptions;
    }

    /// <summary>
    /// 运行应用
    /// </summary>
    /// <param name="args"></param>
    public void Run(string[] args)
    {
        try
        {
            //应用程序启动


            var builder = WebApplication.CreateBuilder(args);
            _hostAppOptions?.ConfigurePreWebApplicationBuilder?.Invoke(builder);

            builder.ConfigureApplication();
            //清空日志供应程序，避免.net自带日志输出到命令台
            //builder.Logging.ClearProviders();
            //使用Serilog日志
            builder.Logging.AddSerilog();

            var services = builder.Services;
            var env = builder.Environment;
            var configuration = builder.Configuration;

            var configHelper = new ConfigHelper();
            var appConfig = ConfigHelper.Get<AppConfig>("appconfig", env.EnvironmentName) ?? new AppConfig();
            var apiConfig = ConfigHelper.Get<ApiConfig>("apiconfig", env.EnvironmentName) ?? new ApiConfig();
            //添加配置
            configuration.AddJsonFile("./Configs/ratelimitconfig.json", optional: true, reloadOnChange: true);
            if (env.EnvironmentName != null)
            {
                configuration.AddJsonFile($"./Configs/ratelimitconfig.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            }
            configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            if (env.EnvironmentName != null)
            {
                configuration.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            }

            //应用配置
            services.AddSingleton(appConfig);
            services.AddSingleton(apiConfig);

            var hostAppContext = new HostAppContext()
            {
                Services = services,
                Environment = env,
                Configuration = configuration
            };

            //使用Autofac容器
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            //配置Autofac容器
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                // 控制器注入
                builder.RegisterModule(new ControllerModule());

                // 单例注入
                builder.RegisterModule(new SingleInstanceModule(appConfig.AssemblyNames));

                // 模块注入
                builder.RegisterModule(new RegisterModule(appConfig.AssemblyNames));

                _hostAppOptions?.ConfigureAutofacContainer?.Invoke(builder, hostAppContext);
            });

            //配置Kestrel服务器
            builder.WebHost.ConfigureKestrel((context, options) =>
            {
                //设置应用服务器Kestrel请求体最大为100MB
                options.Limits.MaxRequestBodySize = appConfig.MaxRequestBodySize;
            });

            //访问地址
            if (appConfig.Urls?.Length > 0)
            {
                builder.WebHost.UseUrls(appConfig.Urls);
            }

            //配置服务
            ConfigureServices(services, env, configuration, configHelper, appConfig, apiConfig);

            _hostAppOptions?.ConfigureWebApplicationBuilder?.Invoke(builder);

            var app = builder.Build();

            app.ConfigureApplication();

            app.Lifetime.ApplicationStarted.Register(() =>
            {
                ServiceBase.IsRun = true;
            });

            app.Lifetime.ApplicationStopped.Register(() =>
            {
                ServiceBase.IsRun = false;
            });

            //配置中间件
            ConfigureMiddleware(app, env, configuration, appConfig, apiConfig);

            app.Run();

            //应用程序停止
            Log.Logger.Information("Application shutdown");
        }
        catch (Exception exception)
        {
            //应用程序异常
            Log.Logger.Error(exception, "Application stopped because of exception");
            throw;
        }
        finally
        {

        }
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="env"></param>
    /// <param name="configuration"></param>
    /// <param name="configHelper"></param>
    /// <param name="appConfig"></param>
    private void ConfigureServices(IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration, ConfigHelper configHelper, AppConfig appConfig, ApiConfig apiConfig)
    {
        var hostAppContext = new HostAppContext()
        {
            Services = services,
            Environment = env,
            Configuration = configuration
        };

        _hostAppOptions?.ConfigurePreServices?.Invoke(hostAppContext);

        //健康检查
        services.AddHealthChecks();

        //雪花漂移算法
        var idGeneratorOptions = new IdGeneratorOptions(1) { WorkerIdBitLength = 6 };
        _hostAppOptions?.ConfigureIdGenerator?.Invoke(idGeneratorOptions);
        YitIdHelper.SetIdGenerator(idGeneratorOptions);

        //权限处理
        services.AddScoped<IPermissionHandler, PermissionHandler>();

        // ClaimType不被更改
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        //用户信息
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.TryAddScoped<IUser, User>();

        //数据库配置
        var dbConfig = ConfigHelper.Get<DbConfig>("dbconfig", env.EnvironmentName);
        services.AddSingleton(dbConfig);

        //添加数据库
        if (!_hostAppOptions.CustomInitDb)
        {
            services.AddAdminDb(env);
        }
        //程序集
        Assembly[] assemblies = AssemblyHelper.GetAssemblyList(appConfig.AssemblyNames);

        #region Mapster 映射配置
        services.AddScoped<IMapper>(sp => new Mapper());
        if (assemblies?.Length > 0)
        {
            TypeAdapterConfig.GlobalSettings.Scan(assemblies);
        }
        #endregion Mapster 映射配置

        #region Cors 跨域
        services.AddCors(options =>
        {
            options.AddPolicy(AdminConsts.RequestPolicyName, policy =>
            {
                var hasOrigins = appConfig.CorUrls?.Length > 0;
                if (hasOrigins)
                {
                    policy.WithOrigins(appConfig.CorUrls);
                }
                else
                {
                    policy.AllowAnyOrigin();
                }
                policy
                .AllowAnyHeader()
                .AllowAnyMethod();

                if (hasOrigins)
                {
                    policy.AllowCredentials();
                }
            });

            //允许任何源访问Api策略，使用时在控制器或者接口上增加特性[EnableCors(AdminConsts.AllowAnyPolicyName)]
            options.AddPolicy(AdminConsts.AllowAnyPolicyName, policy =>
            {
                policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        #endregion Cors 跨域

        #region 身份认证授权

        var jwtConfig = ConfigHelper.Get<JwtConfig>("jwtconfig", env.EnvironmentName);
        services.TryAddSingleton(jwtConfig);

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = nameof(ResponseAuthenticationHandler); //401
            options.DefaultForbidScheme = nameof(ResponseAuthenticationHandler);    //403
        })
        .AddJwtBearer(options =>
        {

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfig.Issuer,
                ValidAudience = jwtConfig.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecurityKey)),
                ClockSkew = TimeSpan.Zero
            };

        })
        .AddScheme<AuthenticationSchemeOptions, ResponseAuthenticationHandler>(nameof(ResponseAuthenticationHandler), o => { });

        #endregion 身份认证授权

        #region Swagger Api文档

        if (env.IsDevelopment() || appConfig.Swagger.Enable)
        {
            services.AddSwaggerGen(options =>
            {
                appConfig.Swagger.Projects?.ForEach(project =>
                {
                    options.SwaggerDoc(project.Code.ToLower(), new OpenApiInfo
                    {
                        Title = project.Name,
                        Version = project.Version,
                        Description = project.Description
                    });
                });

                options.CustomOperationIds(apiDesc =>
                {
                    var controllerAction = apiDesc.ActionDescriptor as ControllerActionDescriptor;
                    var api = controllerAction.AttributeRouteInfo.Template;
                    api = Regex.Replace(api, @"[\{\\\/\}]", "-") + "-" + apiDesc.HttpMethod.ToLower();
                    return api.Replace("--", "-");
                });

                options.ResolveConflictingActions(apiDescription => apiDescription.First());

                string DefaultSchemaIdSelector(Type modelType)
                {
                    var modelName = modelType.Name;
                    if (appConfig.Swagger.EnableSchemaIdNamespace)
                    {
                        var nameSpaceList = appConfig.Swagger.AssemblyNameList;
                        if (nameSpaceList?.Length > 0)
                        {
                            var nameSpace = modelType.Namespace;
                            if (nameSpaceList.Where(a => nameSpace.Contains(a)).Any())
                            {
                                modelName = modelType.FullName;
                            }
                        }
                        else
                        {
                            modelName = modelType.FullName;
                        }
                    }

                    if (modelType.IsConstructedGenericType)
                    {
                        var prefix = modelType.GetGenericArguments()
                        .Select(DefaultSchemaIdSelector)
                        .Aggregate((previous, current) => previous + current);

                        modelName = modelName.Split('`').First() + prefix;
                    }
                    else
                    {
                        modelName = modelName.Replace("[]", "Array");
                    }

                    if (modelType.IsDefined(typeof(SchemaIdAttribute)))
                    {
                        var swaggerSchemaIdAttribute = modelType.GetCustomAttribute<SchemaIdAttribute>(false);
                        if (swaggerSchemaIdAttribute.SchemaId != null)
                        {
                            return swaggerSchemaIdAttribute.SchemaId;
                        }
                        else
                        {
                            return swaggerSchemaIdAttribute.Prefix + modelName + swaggerSchemaIdAttribute.Suffix;
                        }
                    }

                    return modelName;
                }

                options.CustomSchemaIds(modelType => DefaultSchemaIdSelector(modelType));

                //支持多分组
                options.DocInclusionPredicate((docName, apiDescription) =>
                {
                    var nonGroup = false;
                    var groupNames = new List<string>();
                    var dynamicApiAttribute = apiDescription.ActionDescriptor.EndpointMetadata.FirstOrDefault(x => x is DynamicApiAttribute);
                    if (dynamicApiAttribute != null)
                    {
                        var dynamicApi = dynamicApiAttribute as DynamicApiAttribute;
                        if (dynamicApi.GroupNames?.Length > 0)
                        {
                            groupNames.AddRange(dynamicApi.GroupNames);
                        }
                    }

                    var apiGroupAttribute = apiDescription.ActionDescriptor.EndpointMetadata.FirstOrDefault(x => x is ApiGroupAttribute);
                    if (apiGroupAttribute != null)
                    {
                        var apiGroup = apiGroupAttribute as ApiGroupAttribute;
                        if (apiGroup.GroupNames?.Length > 0)
                        {
                            groupNames.AddRange(apiGroup.GroupNames);
                        }
                        nonGroup = apiGroup.NonGroup;
                    }

                    return docName == apiDescription.GroupName || groupNames.Any(a => a == docName) || nonGroup;
                });

                string[] xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
                if (xmlFiles.Length > 0)
                {
                    foreach (var xmlFile in xmlFiles)
                    {
                        options.IncludeXmlComments(xmlFile, true);
                    }
                }

                var server = new OpenApiServer()
                {
                    Url = apiConfig.Swagger.Url,
                    Description = ""
                };
                if (apiConfig.ApiUI.Footer.Enable)
                {
                    server.Extensions.Add("extensions", new OpenApiObject
                    {
                        ["copyright"] = new OpenApiString(apiConfig.ApiUI.Footer.Content)
                    });
                }
                options.AddServer(server);

                if (apiConfig.Swagger.EnableEnumSchemaFilter)
                {
                    options.SchemaFilter<EnumSchemaFilter>();
                }
                if (apiConfig.Swagger.EnableOrderTagsDocumentFilter)
                {
                    options.DocumentFilter<OrderTagsDocumentFilter>();
                }
                options.OrderActionsBy(apiDesc =>
                {
                    var order = 0;
                    var objOrderAttribute = apiDesc.CustomAttributes().FirstOrDefault(x => x is OrderAttribute);
                    if (objOrderAttribute != null)
                    {
                        var orderAttribute = objOrderAttribute as OrderAttribute;
                        order = orderAttribute.Value;
                    }
                    return (int.MaxValue - order).ToString().PadLeft(int.MaxValue.ToString().Length, '0');
                });

                #region 添加设置Token的按钮


                //添加Jwt验证设置
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                    });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Value: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });


                #endregion 添加设置Token的按钮
            });
        }

        #endregion Swagger Api文档

        #region 操作日志

        services.AddScoped<ILogHandler, LogHandler>();

        #endregion 操作日志

        #region 控制器
        void mvcConfigure(MvcOptions options)
        {
            //options.Filters.Add<ControllerExceptionFilter>();
            options.Filters.Add<ValidateInputFilter>();
            if (appConfig.Validate.Login || appConfig.Validate.Permission)
            {
                options.Filters.Add<ValidatePermissionAttribute>();
            }
            //在具有较高的 Order 值的筛选器之前运行 before 代码
            //在具有较高的 Order 值的筛选器之后运行 after 代码
            if (appConfig.DynamicApi.FormatResult)
            {
                options.Filters.Add<FormatResultFilter>(20);
            }

            options.Filters.Add<ControllerLogFilter>(10);

            //禁止去除ActionAsync后缀
            //options.SuppressAsyncSuffixInActionNames = false;

            if (env.IsDevelopment() || appConfig.Swagger.Enable)
            {
                //API分组约定
                options.Conventions.Add(new ApiGroupConvention());
            }
        }

        var mvcBuilder = services.AddControllers(mvcConfigure);

        if (assemblies?.Length > 0)
        {
            foreach (var assembly in assemblies)
            {
                services.AddValidatorsFromAssembly(assembly);
            }
        }
        services.AddFluentValidationAutoValidation();

        mvcBuilder.AddJsonOptions(options =>
        {
            //忽略循环引用
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //使用驼峰 首字母小写
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //取消Unicode编码
            options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            //允许额外符号
            options.JsonSerializerOptions.AllowTrailingCommas = true;
            //设置时间格式
            options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
        })
        .AddControllersAsServices();

        if (appConfig.Swagger.EnableJsonStringEnumConverter)
            mvcBuilder.AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        _hostAppOptions?.ConfigureMvcBuilder?.Invoke(mvcBuilder, hostAppContext);
        #endregion 控制器

        services.AddHttpClient();

        _hostAppOptions?.ConfigureServices?.Invoke(hostAppContext);

        #region 缓存
        //添加内存缓存
        services.AddMemoryCache();

        var cacheConfig = ConfigHelper.Get<CacheConfig>("cacheconfig", env.EnvironmentName);
        if (cacheConfig.Type == CacheType.Redis)
        {
            ////FreeRedis客户端
            //var redis = new RedisClient(cacheConfig.Redis.ConnectionString)
            //{
            //	Serialize = JsonConvert.SerializeObject,
            //	Deserialize = JsonConvert.DeserializeObject
            //};
            //services.AddSingleton(redis);
            ////Redis缓存
            //services.AddSingleton<ICacheTool, RedisCacheTool>();
            ////分布式Redis缓存
            //services.AddSingleton<IDistributedCache>(new DistributedCache(redis));
        }
        else
        {
            //内存缓存
            services.AddSingleton<ICacheTool, MemoryCacheTool>();
            //分布式内存缓存
            services.AddDistributedMemoryCache();
        }

        #endregion 缓存

        //#region IP限流

        //if (appConfig.RateLimit)
        //{
        //    services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
        //    services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

        //    //if (cacheConfig.TypeRateLimit == CacheType.Redis)
        //    //{
        //    //    services.AddDistributedRateLimiting();
        //    //}
        //    //else
        //    //{
        //    services.AddInMemoryRateLimiting();
        //    //}
        //    services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        //    services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        //}

        //#endregion IP限流

        //阻止NLog接收状态消息
        services.Configure<ConsoleLifetimeOptions>(opts => opts.SuppressStatusMessages = true);

        //性能分析
        if (appConfig.MiniProfiler)
        {
            services.AddMiniProfiler();
        }

        //动态api
        services.AddDynamicApi(options =>
        {
            options.FormatResult = appConfig.DynamicApi.FormatResult;
            options.FormatResultType = typeof(ResultOutput<>);

            _hostAppOptions?.ConfigureDynamicApi?.Invoke(options);
        });


        ////滑块验证码
        //services.AddSlideCaptcha(configuration, options =>
        //{
        //    options.StoreageKeyPrefix = CacheKeys.Captcha;
        //});
        //services.AddScoped<ISlideCaptcha, SlideCaptcha>();

        _hostAppOptions?.ConfigurePostServices?.Invoke(hostAppContext);
    }

    /// <summary>
    /// 配置中间件
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="configuration"></param>
    /// <param name="appConfig"></param>
    private void ConfigureMiddleware(WebApplication app, IWebHostEnvironment env, IConfiguration configuration, AppConfig appConfig, ApiConfig apiConfig)
    {
        var hostAppMiddlewareContext = new HostAppMiddlewareContext()
        {
            App = app,
            Environment = env,
            Configuration = configuration
        };

        _hostAppOptions?.ConfigurePreMiddleware?.Invoke(hostAppMiddlewareContext);

        //异常处理
        app.UseMiddleware<ExceptionMiddleware>();

        //IP限流

        //app.UseIpRateLimiting();


        //性能分析
        if (appConfig.MiniProfiler)
        {
            app.UseMiniProfiler();
        }

        //静态文件
        app.UseDefaultFiles();
        app.UseStaticFiles();

        //路由
        app.UseRouting();

        //跨域
        app.UseCors(AdminConsts.RequestPolicyName);

        //认证
        app.UseAuthentication();

        //授权
        app.UseAuthorization();

        ////登录用户初始化数据权限
        //if (appConfig.Validate.DataPermission)
        //{
        //	app.Use(async (ctx, next) =>
        //	{
        //		var user = ctx.RequestServices.GetRequiredService<IUser>();
        //		if (user?.Id > 0)
        //		{
        //			var userService = ctx.RequestServices.GetRequiredService<IUserService>();
        //			await userService.GetDataPermissionAsync();
        //		}

        //		await next();
        //	});
        //}

        //配置端点
        app.MapControllers();

        _hostAppOptions?.ConfigureMiddleware?.Invoke(hostAppMiddlewareContext);

        #region Swagger Api文档
        if (env.IsDevelopment() || apiConfig.Swagger.Enable)
        {
            var routePrefix = apiConfig.ApiUI.RoutePrefix;
            if (!apiConfig.ApiUI.Enable && routePrefix == null)
            {
                routePrefix = apiConfig.Swagger.RoutePrefix;
            }
            var routePath = routePrefix != null ? $"{routePrefix}/" : "";
            app.UseSwagger(optoins =>
            {
                optoins.RouteTemplate = routePath + optoins.RouteTemplate;
            });
            app.UseApiUI(options =>
            {
                options.RoutePrefix = apiConfig.Swagger.RoutePrefix;
                apiConfig.Swagger.Projects?.ForEach(project =>
                {
                    options.SwaggerEndpoint($"/{routePath}swagger/{project.Code.ToLower()}/swagger.json", project.Name);
                });

                options.DocExpansion(DocExpansion.None);//折叠Api
                                                        //options.DefaultModelsExpandDepth(-1);//不显示Models
                if (appConfig.MiniProfiler)
                {
                    options.InjectJavascript("/swagger/mini-profiler.js?v=4.2.22+2.0");
                    options.InjectStylesheet("/swagger/mini-profiler.css?v=4.2.22+2.0");
                }
            });
        }
        #endregion Swagger Api文档

        //使用健康检查
        if (appConfig.HealthChecks.Enable)
        {
            app.MapHealthChecks(appConfig.HealthChecks.Path, new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }

        _hostAppOptions?.ConfigurePostMiddleware?.Invoke(hostAppMiddlewareContext);
    }
}
