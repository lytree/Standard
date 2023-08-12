using Mapster;
using Service.Admin.Permission.Dto;
using System.Linq;
using ZhonTai.Admin.Domain.Permission;

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