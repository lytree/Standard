using Infrastructure.Service;
using Repository.Admin;
using Service.Admin.Role.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Admin.Role;

/// <summary>
/// 角色接口
/// </summary>
public interface IRoleService
{
	Task<RoleGetOutput> GetAsync(long id);

	Task<List<RoleGetListOutput>> GetListAsync(RoleGetListInput input);

	Task<PageOutput<RoleGetPageOutput>> GetPageAsync(PageInput<RoleGetPageDto> input);

	Task<long> AddAsync(RoleAddInput input);

	Task AddRoleUserAsync(RoleAddRoleUserListInput input);

	Task RemoveRoleUserAsync(RoleAddRoleUserListInput input);

	Task UpdateAsync(RoleUpdateInput input);

	Task DeleteAsync(long id);

	Task BatchDeleteAsync(long[] ids);

	Task SoftDeleteAsync(long id);

	Task BatchSoftDeleteAsync(long[] ids);

	Task SetDataScopeAsync(RoleSetDataScopeInput input);
}