﻿using System.ComponentModel.DataAnnotations;
using Infrastructure.Service;

namespace Service.Admin.Permission.Dto;

public class PermissionUpdateApiInput : PermissionAddApiInput
{
	/// <summary>
	/// 权限Id
	/// </summary>
	[Required]
	[ValidateRequired("请选择接口")]
	public long Id { get; set; }
}