﻿namespace Repository.Admin;
public partial class RoleGetRoleUserListInput
{
	/// <summary>
	/// 姓名
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// 角色Id
	/// </summary>
	public long? RoleId { get; set; }
}