using Repository.Admin.Repository.User;

namespace Service.Admin.Auth.Dto;

public class AuthLoginOutput
{
	/// <summary>
	/// 主键Id
	/// </summary>
	public long Id { get; set; }

	/// <summary>
	/// 账号
	/// </summary>
	public string UserName { get; set; }

	/// <summary>
	/// 姓名
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// 用户类型
	/// </summary>
	public UserType Type { get; set; }

	/// <summary>
	/// 启用
	/// </summary>
	public bool Enabled { get; set; }
}