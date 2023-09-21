using Autofac;
using Autofac.Extras.DynamicProxy;
using Infrastructure;
using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;
namespace Repository.Admin.Core;

public class AdminRepositoryRegisterModule : Module
{


	/// <summary>
	/// 模块注入
	/// </summary>
	/// <param name="appConfig">AppConfig</param>
	public AdminRepositoryRegisterModule()
	{
		
	}
	protected override void Load(ContainerBuilder builder)
	{

		//事务拦截
		var interceptorServiceTypes = new List<Type>();


		//程序集
		Assembly assemblies = Assembly.GetExecutingAssembly();

		static bool Predicate(Type a) => !a.IsDefined(typeof(NonRegisterIOCAttribute), true)
			&& (a.Name.EndsWith("Repository"))
			&& !a.IsAbstract && !a.IsInterface && a.IsPublic;

		//有接口实例
		builder.RegisterAssemblyTypes(assemblies)
		.Where(new Func<Type, bool>(Predicate))
		.AsImplementedInterfaces()
		.InstancePerLifetimeScope()
		.PropertiesAutowired()// 属性注入
		.InterceptedBy(interceptorServiceTypes.ToArray())
		.EnableInterfaceInterceptors();

		//无接口实例
		builder.RegisterAssemblyTypes(assemblies)
		.Where(new Func<Type, bool>(Predicate))
		.InstancePerLifetimeScope()
		.PropertiesAutowired()// 属性注入
		.InterceptedBy(interceptorServiceTypes.ToArray())
		.EnableClassInterceptors();




	}
}
