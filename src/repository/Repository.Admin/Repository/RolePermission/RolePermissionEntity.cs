﻿using FreeSql.DataAnnotations;
using Repository.Admin.Core;
using Repository.Admin.Repository.Permission;
using Repository.Admin.Repository.Role;

namespace Repository.Admin.Repository.RolePermission;
/// <summary>
/// 角色权限
/// </summary>
[Table(Name = "ad_role_permission")]
[Index("idx_{tablename}_01", nameof(RoleId) + "," + nameof(PermissionId), true)]
public class RolePermissionEntity : EntityAdd
{
    /// <summary>
    /// 角色Id
    /// </summary>
    public long RoleId { get; set; }

    /// <summary>
    /// 权限Id
    /// </summary>
    public long PermissionId { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    [NotGen]
    public RoleEntity Role { get; set; }

    /// <summary>
    /// 权限
    /// </summary>
    [NotGen]
    public PermissionEntity Permission { get; set; }
}