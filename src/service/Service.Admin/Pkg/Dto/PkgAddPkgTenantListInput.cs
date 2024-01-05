using System.ComponentModel.DataAnnotations;

namespace Service.Admin.Pkg.Dto;

/// <summary>
/// 添加套餐租户列表
/// </summary>
public class PkgAddPkgTenantListInput
{
    /// <summary>
    /// 套餐
    /// </summary>
    [Required(ErrorMessage = "请选择套餐")]
    public long PkgId { get; set; }

}