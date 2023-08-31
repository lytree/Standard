using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;
namespace Infrastructure.Core;

public class SingleInstanceModule : Module
{
	private readonly string[]? _assemblyNames;

	/// <summary>
	/// 单例注入
	/// </summary>
	/// <param name="appConfig">AppConfig</param>
	public SingleInstanceModule(params string[] assemblyName)
	{
		_assemblyNames = assemblyName;
	}

	protected override void Load(ContainerBuilder builder)
	{
		if (_assemblyNames?.Length > 0)
		{
			// 获得要注入的程序集
			Assembly[] assemblies = AssemblyHelper.GetAssemblyList(_assemblyNames);

			//无接口注入单例
			builder.RegisterAssemblyTypes(assemblies)
			.Where(t => t.GetCustomAttribute<SingleInstanceAttribute>(false) != null)
			.SingleInstance()
			.PropertiesAutowired();

			//有接口注入单例
			builder.RegisterAssemblyTypes(assemblies)
			.Where(t => t.GetCustomAttribute<SingleInstanceAttribute>(false) != null)
			.AsImplementedInterfaces()
			.SingleInstance()
			.PropertiesAutowired();
		}
	}
}
