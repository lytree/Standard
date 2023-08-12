using System;
using System.Reflection;

/* 项目“Plugin.DynamicApi (net7.0)”的未合并的更改
在此之前:
using Plugin.DynamicApi.Attributes;
在此之后:
using Plugin.DynamicApi.Attributes;
using ZhonTai;
using ZhonTai.DynamicApi;
using Plugin.DynamicApi;
*/
using Plugin.DynamicApi.Attributes;
using Plugin.DynamicApi.Helpers;

namespace Plugin.DynamicApi;

public interface ISelectController
{
	bool IsController(Type type);
}

internal class DefaultSelectController : ISelectController
{
	public bool IsController(Type type)
	{
		var typeInfo = type.GetTypeInfo();

		if (!typeof(IDynamicApi).IsAssignableFrom(type) ||
			!typeInfo.IsPublic || typeInfo.IsAbstract || typeInfo.IsGenericType)
		{
			return false;
		}


		var attr = ReflectionHelper.GetSingleAttributeOrDefaultByFullSearch<DynamicApiAttribute>(typeInfo);

		if (attr == null)
		{
			return false;
		}

		if (ReflectionHelper.GetSingleAttributeOrDefaultByFullSearch<NonDynamicApiAttribute>(typeInfo) != null)
		{
			return false;
		}

		return true;
	}
}