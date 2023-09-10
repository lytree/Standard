﻿using System.ComponentModel.DataAnnotations;
using Infrastructure.Service;

namespace Service.Admin.Permission.Dto;

public class PermissionUpdateDotInput : PermissionAddDotInput
{
	/// <summary>
	/// 权限Id
	/// </summary>
	[Required]
	[ValidateRequired("请选择权限点")]
	public long Id { get; set; }
}