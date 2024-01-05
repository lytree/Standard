using System.ComponentModel.DataAnnotations;
using Infrastructure.Service;

namespace Service.Admin.Config.Dto;

/// <summary>
/// 修改
/// </summary>
public class ConfigUpdateInput : ConfigAddInput
{
	/// <summary>
	/// 主键Id
	/// </summary>
	[Required]
	[ValidateRequired("请选择数据字典")]
	public long Id { get; set; }
}