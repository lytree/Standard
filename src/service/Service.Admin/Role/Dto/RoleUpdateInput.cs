﻿using Infrastructure.Service;
using System.ComponentModel.DataAnnotations;


namespace Service.Admin.Role.Dto;

/// <summary>
/// 修改
/// </summary>
public partial class RoleUpdateInput : RoleAddInput
{
	/// <summary>
	/// 角色Id
	/// </summary>
	[Required]
	[ValidateRequired("请选择角色")]
	public long Id { get; set; }
}