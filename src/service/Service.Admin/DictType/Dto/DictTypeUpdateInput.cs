﻿using System.ComponentModel.DataAnnotations;
using Infrastructure.Service;

namespace Service.Admin.DictType.Dto;

/// <summary>
/// 修改
/// </summary>
public class DictTypeUpdateInput : DictTypeAddInput
{
	/// <summary>
	/// 主键Id
	/// </summary>
	[Required]
	[ValidateRequired("请选择数据字典类型")]
	public long Id { get; set; }
}