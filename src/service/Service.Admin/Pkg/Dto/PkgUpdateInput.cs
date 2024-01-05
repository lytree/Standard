﻿using Infrastructure.Service;
using System.ComponentModel.DataAnnotations;

namespace Service.Admin.Pkg.Dto;

/// <summary>
/// 修改
/// </summary>
public partial class PkgUpdateInput : PkgAddInput
{
    /// <summary>
    /// 套餐Id
    /// </summary>
    [Required]
    [ValidateRequired("请选择套餐")]
    public long Id { get; set; }
}