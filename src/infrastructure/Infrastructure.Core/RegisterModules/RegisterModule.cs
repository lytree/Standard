using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace Infrastructure.Core;

public class RegisterModule : Module
{
	private readonly string[]? _assemblyNames;


	/// <summary>
	/// 模块注入
	/// </summary>
	/// <param name="appConfig">AppConfig</param>
	public RegisterModule(params string[] assemblyNames)
	{
		_assemblyNames = assemblyNames;
	}
	protected override void Load(ContainerBuilder builder)
	{

		//事务拦截
		var interceptorServiceTypes = new List<Type>();

		if (_assemblyNames?.Length > 0)
		{
			//程序集
			Assembly[] assemblies = AssemblyHelper.GetAssemblyList(_assemblyNames);

			static bool Predicate(Type a) => !a.IsDefined(typeof(NonRegisterIOCAttribute), true)
				&&( typeof(IRegisterIOC).IsAssignableFrom(a))
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
}

