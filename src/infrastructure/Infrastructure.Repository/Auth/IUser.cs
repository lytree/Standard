

namespace Infrastructure.Repository;

/// <summary>
/// 用户信息接口
/// </summary>
public interface IUser
{
	/// <summary>
	/// 用户Id
	/// </summary>
	long Id { get; }

	/// <summary>
	/// 用户名
	/// </summary>
	string UserName { get; }

	/// <summary>
	/// 姓名
	/// </summary>
	string Name { get; }

	/// <summary>
	/// 默认用户
	/// </summary>
	bool DefaultUser { get; }

	/// <summary>
	/// 平台管理员
	/// </summary>
	bool PlatformAdmin { get; }
}