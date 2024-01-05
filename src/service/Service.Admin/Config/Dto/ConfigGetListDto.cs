using Newtonsoft.Json;

namespace Service.Admin.Config.Dto;

public class ConfigGetListDto
{

	/// <summary>
	/// 主键Id
	/// </summary>
	public long Id { get; set; }

	/// <summary>
	/// 字典名称
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// 字典编码
	/// </summary>
	public string Code { get; set; }

	/// <summary>
	/// 字典值
	/// </summary>
	public string Value { get; set; }
}