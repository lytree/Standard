using System.Linq;
using System.Threading.Tasks;
using Service.Admin.Pkg.Dto;
using Microsoft.AspNetCore.Mvc;
using Plugin.DynamicApi.Attributes;
using Plugin.DynamicApi;
using Repository.Admin.Repository.Pkg;
using Repository.Admin.Repository.PkgData;
using Repository.Admin.Repository.PkgPermission;
using Repository.Admin.Repository.RolePermission;
using Repository.Admin.Repository.User;
using Infrastructure;

namespace Service.Admin.Pkg;

/// <summary>
/// 客户套餐服务 
/// </summary>
/// todo
[Order(51)]
[DynamicApi(Area = AdminConsts.AreaName)]
public class PkgService : BaseService,IPkgService, IDynamicApi
{
	private IPkgRepository _pkgRepository => LazyGetRequiredService<IPkgRepository>();
	private IPkgDataRepository _pkgDataRepository => LazyGetRequiredService<IPkgDataRepository>();
	private IPkgPermissionRepository _pkgPermissionRepository => LazyGetRequiredService<IPkgPermissionRepository>();
	private IRolePermissionRepository _rolePermissionRepository => LazyGetRequiredService<IRolePermissionRepository>();
	private IUserRepository _userRepository => LazyGetRequiredService<IUserRepository>();

	public PkgService()
	{
	}

	/// <summary>
	/// 清除所有用户权限缓存
	/// </summary>
	[NonAction]
	public async Task ClearUserPermissionsAsync()
	{
		var userIds = await _userRepository.Select.ToListAsync(a => a.Id);
		if (userIds.Any())
		{
			foreach (var userId in userIds)
			{
				await Cache.DelAsync(CacheKeys.UserPermissions + userId);
			}
		}
	}

	/// <summary>
	/// 查询
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task<PkgGetOutput> GetAsync(long id)
	{
		return await _pkgRepository.Select
		.WhereDynamic(id)
		.ToOneAsync<PkgGetOutput>();
	}

	/// <summary>
	/// 查询列表
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public async Task<List<PkgGetListOutput>> GetListAsync([FromQuery] PkgGetListInput input)
	{
		var list = await _pkgRepository.Select
		.WhereIf(input.Name != null, a => a.Name.Contains(input.Name))
		.OrderBy(a => new { a.ParentId, a.Sort })
		.ToListAsync<PkgGetListOutput>();

		return list;
	}

	/// <summary>
	/// 查询分页
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	[HttpPost]
	public async Task<PageOutput<PkgGetPageOutput>> GetPageAsync(PageInput<PkgGetPageDto> input)
	{
		var key = input.Filter?.Name;

		var list = await _pkgRepository.Select
		.WhereDynamicFilter(input.DynamicFilter)
		.WhereIf(key != null, a => a.Name.Contains(key))
		.Count(out var total)
		.OrderByDescending(true, c => c.Id)
		.Page(input.CurrentPage, input.PageSize)
		.ToListAsync<PkgGetPageOutput>();

		var data = new PageOutput<PkgGetPageOutput>()
		{
			List = list,
			Total = total
		};

		return data;
	}


	/// <summary>
	/// 查询套餐权限列表
	/// </summary>
	/// <param name="pkgId">套餐编号</param>
	/// <returns></returns>
	public async Task<List<long>> GetPkgPermissionListAsync(long pkgId)
	{
		var permissionIds = await _pkgPermissionRepository
			.Select.Where(d => d.PkgId == pkgId)
			.ToListAsync(a => a.PermissionId);

		return permissionIds;
	}

	/// <summary>
	/// 设置套餐权限
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	[AdminTransaction]
	public virtual async Task SetPkgPermissionsAsync(PkgSetPkgPermissionsInput input)
	{
		//查询套餐权限
		var permissionIds = await _pkgPermissionRepository.Select.Where(d => d.PkgId == input.PkgId).ToListAsync(m => m.PermissionId);

		//批量删除套餐权限
		var deleteIds = permissionIds.Where(d => !input.PermissionIds.Contains(d));
		if (deleteIds.Any())
		{
			//删除套餐权限
			await _pkgPermissionRepository.DeleteAsync(m => m.PkgId == input.PkgId && deleteIds.Contains(m.PermissionId));
			//删除套餐下关联的角色权限
			await _rolePermissionRepository.DeleteAsync(a => deleteIds.Contains(a.PermissionId));
		}

		//批量插入套餐权限
		var pkgPermissions = new List<PkgPermissionEntity>();
		var insertPermissionIds = input.PermissionIds.Where(d => !permissionIds.Contains(d));
		if (insertPermissionIds.Any())
		{
			foreach (var permissionId in insertPermissionIds)
			{
				pkgPermissions.Add(new PkgPermissionEntity()
				{
					PkgId = input.PkgId,
					PermissionId = permissionId,
				});
			}
			await _pkgPermissionRepository.InsertAsync(pkgPermissions);
		}


		//清除租户下所有用户权限缓存
		await ClearUserPermissionsAsync();
	}

	///// <summary>
	///// 添加套餐租户
	///// </summary>
	///// <param name="input"></param>
	///// <returns></returns>
	//public async Task AddPkgTenantAsync(PkgAddPkgTenantListInput input)
	//{
	//	var pkgId = input.PkgId;
	//	var insertTenantIds = input.TenantIds.Except(tenantIds);
	//	if (insertTenantIds != null && insertTenantIds.Any())
	//	{
	//		var tenantPkgList = insertTenantIds.Select(tenantId => new TenantPkgEntity
	//		{
	//			TenantId = tenantId,
	//			PkgId = pkgId
	//		}).ToList();
	//		await _pkgDataRepository.InsertAsync(tenantPkgList);

	//		//清除租户下所有用户权限缓存
	//		await ClearUserPermissionsAsync(insertTenantIds.ToList());
	//	}
	//}

	/// <summary>
	/// 移除套餐租户
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	[HttpPost]
	public async Task RemovePkgTenantAsync(PkgAddPkgTenantListInput input)
	{
		//清除租户下所有用户权限缓存
		await ClearUserPermissionsAsync();

	}

	/// <summary>
	/// 新增
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public async Task<long> AddAsync(PkgAddInput input)
	{
		if (await _pkgRepository.Select.AnyAsync(a => a.ParentId == input.ParentId && a.Name == input.Name))
		{
			throw ResultOutput.Exception($"此套餐名已存在");
		}

		if (input.Code != null && await _pkgRepository.Select.AnyAsync(a => a.ParentId == input.ParentId && a.Code == input.Code))
		{
			throw ResultOutput.Exception($"此套餐编码已存在");
		}

		var entity = Mapper.Map<PkgEntity>(input);
		if (entity.Sort == 0)
		{
			var sort = await _pkgRepository.Select.Where(a => a.ParentId == input.ParentId).MaxAsync(a => a.Sort);
			entity.Sort = sort + 1;
		}

		await _pkgRepository.InsertAsync(entity);

		return entity.Id;
	}

	/// <summary>
	/// 修改
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public async Task UpdateAsync(PkgUpdateInput input)
	{
		var entity = await _pkgRepository.GetAsync(input.Id);
		if (!(entity?.Id > 0))
		{
			throw ResultOutput.Exception("套餐不存在");
		}

		if (await _pkgRepository.Select.AnyAsync(a => a.ParentId == input.ParentId && a.Id != input.Id && a.Name == input.Name))
		{
			throw ResultOutput.Exception($"此套餐名已存在");
		}

		if (input.Code != null && await _pkgRepository.Select.AnyAsync(a => a.ParentId == input.ParentId && a.Id != input.Id && a.Code == input.Code))
		{
			throw ResultOutput.Exception($"此套餐编码已存在");
		}

		Mapper.Map(input, entity);
		await _pkgRepository.UpdateAsync(entity);

		await Cache.DelAsync(CacheKeys.PkgDataPermission + entity.Id);

	}

	/// <summary>
	/// 彻底删除
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[AdminTransaction]
	public virtual async Task DeleteAsync(long id)
	{
		var pkgIdList = await _pkgRepository.GetChildIdListAsync(id);

		//删除套餐权限
		await _pkgPermissionRepository.DeleteAsync(a => pkgIdList.Contains(a.PkgId));
		//删除套餐
		await _pkgRepository.DeleteAsync(a => pkgIdList.Contains(a.Id));

		//清除租户下所有用户权限缓存
		await ClearUserPermissionsAsync();
	}

	/// <summary>
	/// 批量彻底删除
	/// </summary>
	/// <param name="ids"></param>
	/// <returns></returns>
	[AdminTransaction]
	public virtual async Task BatchDeleteAsync(long[] ids)
	{
		var pkgIdList = await _pkgRepository.GetChildIdListAsync(ids);

		//删除租户套餐
		await _pkgDataRepository.DeleteAsync(a => pkgIdList.Contains(a.PkgId));
		//删除套餐权限
		await _pkgPermissionRepository.DeleteAsync(a => pkgIdList.Contains(a.PkgId));
		//删除套餐
		await _pkgRepository.Where(a => pkgIdList.Contains(a.Id)).AsTreeCte().ToDelete().ExecuteAffrowsAsync();

		//清除租户下所有用户权限缓存
		await ClearUserPermissionsAsync();
	}

	/// <summary>
	/// 删除
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[AdminTransaction]
	public virtual async Task SoftDeleteAsync(long id)
	{
		var pkgIdList = await _pkgRepository.GetChildIdListAsync(id);
		await _pkgDataRepository.DeleteAsync(a => pkgIdList.Contains(a.PkgId));
		await _pkgPermissionRepository.DeleteAsync(a => pkgIdList.Contains(a.PkgId));
		await _pkgRepository.SoftDeleteRecursiveAsync(a => pkgIdList.Contains(a.Id));

		//清除租户下所有用户权限缓存
		await ClearUserPermissionsAsync();
	}

	/// <summary>
	/// 批量删除
	/// </summary>
	/// <param name="ids"></param>
	/// <returns></returns>
	[AdminTransaction]
	public virtual async Task BatchSoftDeleteAsync(long[] ids)
	{
		var pkgIdList = await _pkgRepository.GetChildIdListAsync(ids);
		await _pkgDataRepository.DeleteAsync(a => pkgIdList.Contains(a.PkgId));
		await _pkgPermissionRepository.DeleteAsync(a => pkgIdList.Contains(a.PkgId));
		await _pkgRepository.SoftDeleteRecursiveAsync(a => pkgIdList.Contains(a.Id));

		//清除租户下所有用户权限缓存
		await ClearUserPermissionsAsync();
	}
}