﻿namespace Service.Admin.Pkg.Dto;

public partial class PkgGetPkgTenantListInput
{
    /// <summary>
    /// 租户名
    /// </summary>
    public string TenantName { get; set; }

    /// <summary>
    /// 套餐Id
    /// </summary>
    public long? PkgId { get; set; }
}