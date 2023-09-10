using Mapster;
using Repository.Admin.Repository.Permission;
using Service.Admin.Permission.Dto;
using System.Linq;

namespace Service.Admin.Permission;

/// <summary>
/// 映射配置
/// </summary>
public class MapConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config
		.NewConfig<PermissionEntity, PermissionGetDotOutput>()
		.Map(dest => dest.ApiIds, src => src.Apis.Select(a => a.Id));
	}
}