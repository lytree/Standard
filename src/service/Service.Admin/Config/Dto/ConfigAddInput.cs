using Infrastructure.Service;
using System.ComponentModel.DataAnnotations;

namespace Service.Admin.Config.Dto;

/// <summary>
/// 添加字典
/// </summary>
public class ConfigAddInput
{

	/// <summary>
	/// 配置项名称
	/// </summary>
	[Required(ErrorMessage = "请输入配置项名称")]
	public string Name { get; set; }

	/// <summary>
	/// 配置项编码
	/// </summary>
	public string Code { get; set; }

	/// <summary>
	/// 配置项值
	/// </summary>
	public string Value { get; set; }

	/// <summary>
	/// 描述
	/// </summary>
	public string Description { get; set; }

	/// <summary>
	/// 启用
	/// </summary>
	public bool Enabled { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public int Sort { get; set; }
}