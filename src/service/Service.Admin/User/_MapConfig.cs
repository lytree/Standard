using Mapster;
using Service.Admin.User.Dto;
using System.Linq;

namespace Service.Admin.User;

/// <summary>
/// 映射配置
/// </summary>
public class MapConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config
		.NewConfig<UserGetPageOutput, UserGetPageOutput>()
		.Map(dest => dest.RoleNames, src => src.Roles.Select(a => a.Name));
	}
}