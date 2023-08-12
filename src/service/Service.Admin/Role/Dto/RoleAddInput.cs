﻿
using Repository.Admin;
using System.Collections.Generic;


namespace Service.Admin.Role.Dto;

/// <summary>
/// 添加
/// </summary>
public class RoleAddInput
{
	/// <summary>
	/// 父级Id
	/// </summary>
	public long ParentId { get; set; }

	/// <summary>
	/// 名称
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// 编码
	/// </summary>
	public string Code { get; set; }

	/// <summary>
	/// 角色类型
	/// </summary>
	public RoleType Type { get; set; }


	/// <summary>
	/// 说明
	/// </summary>
	public string Description { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public int Sort { get; set; }
}