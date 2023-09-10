using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSql;
using System.Reflection;
using Repository.Admin.Core;
using Repository.Admin.Repository.Role;
using Repository.Admin.Repository.User;
using Repository.Admin.Repository.View;
using Repository.Admin.Repository.UserRole;
using Repository.Admin.Repository.RolePermission;
using Repository.Admin.Repository.Permission;
using Repository.Admin.Repository.DictType;
using Repository.Admin.Repository.Dict;
using Repository.Admin.Repository.Api;
using Repository.Admin.Repository.PermissionApi;

namespace Repository.Admin;
/// <summary>
/// 生成数据
/// </summary>
public class CustomGenerateData : GenerateData, IGenerateData
{
	public virtual async Task GenerateDataAsync(IFreeSql db)
	{
		#region 读取数据

		//admin
		#region 数据字典

		var dictionaryTypes = await db.Queryable<DictTypeEntity>().ToListAsync();

		var dictionaries = await db.Queryable<DictEntity>().ToListAsync();
		#endregion

		#region 接口

		var apis = await db.Queryable<ApiEntity>().ToListAsync();
		var apiTree = apis.Clone().ToTree((r, c) =>
		{
			return c.ParentId == 0;
		},
		(r, c) =>
		{
			return r.Id == c.ParentId;
		},
		(r, datalist) =>
		{
			r.Childs ??= new List<ApiEntity>();
			r.Childs.AddRange(datalist);
		});

		#endregion

		#region 视图

		var views = await db.Queryable<ViewEntity>().ToListAsync();
		var viewTree = views.Clone().ToTree((r, c) =>
		{
			return c.ParentId == 0;
		},
	   (r, c) =>
	   {
		   return r.Id == c.ParentId;
	   },
	   (r, datalist) =>
	   {
		   r.Childs ??= new List<ViewEntity>();
		   r.Childs.AddRange(datalist);
	   });

		#endregion

		#region 权限

		var permissions = await db.Queryable<PermissionEntity>().ToListAsync();
		var permissionTree = permissions.Clone().ToTree((r, c) =>
		{
			return c.ParentId == 0;
		},
	   (r, c) =>
	   {
		   return r.Id == c.ParentId;
	   },
	   (r, datalist) =>
	   {
		   r.Childs ??= new List<PermissionEntity>();
		   r.Childs.AddRange(datalist);
	   });

		#endregion

		#region 用户

		var users = await db.Queryable<UserEntity>().ToListAsync();

		#endregion



		#region 角色

		var roles = await db.Queryable<RoleEntity>().ToListAsync();

		#endregion

		#region 用户角色

		var userRoles = await db.Queryable<UserRoleEntity>().ToListAsync();

		#endregion

		#region 角色权限

		var rolePermissions = await db.Queryable<RolePermissionEntity>().ToListAsync();

		#endregion

		#region 权限接口

		var permissionApis = await db.Queryable<PermissionApiEntity>().ToListAsync();

		#endregion

		#endregion

		#region 生成数据


		SaveDataToJsonFile<UserEntity>(users);
		SaveDataToJsonFile<RoleEntity>(roles);
		SaveDataToJsonFile<DictEntity>(dictionaries);
		SaveDataToJsonFile<DictTypeEntity>(dictionaryTypes);
		SaveDataToJsonFile<UserRoleEntity>(userRoles);
		SaveDataToJsonFile<ApiEntity>(apiTree);
		SaveDataToJsonFile<ViewEntity>(viewTree);
		SaveDataToJsonFile<PermissionEntity>(permissionTree);
		SaveDataToJsonFile<PermissionApiEntity>(permissionApis);
		SaveDataToJsonFile<RolePermissionEntity>(rolePermissions);

		#endregion
	}
}
