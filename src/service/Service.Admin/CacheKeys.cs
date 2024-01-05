using Infrastructure.Cache.Attributes;
using System.ComponentModel;


namespace Service.Admin;
/// <summary>
/// 缓存键
/// </summary>
[ScanCacheKeys]
public static partial class CacheKeys
{

	/// <summary>
	/// 密码加密 admin:password:encrypt:guid
	/// </summary>
	[Description("密码加密")]
	public const string PassWordEncrypt = "admin:password:encrypt:";

	/// <summary>
	/// 用户权限 admin:user:permissions:用户主键
	/// </summary>
	[Description("用户权限")]
	public const string UserPermissions = "admin:user:permissions:";
	/// <summary>
	/// 用户权限 admin:user:permissions:用户主键
	/// </summary>
	[Description("客户权限")]
	public const string PkgPermissions = "admin:user:pkg:permissions:";
	/// <summary>
	/// 数据权限 admin:user:data:permission:用户主键
	/// </summary>
	[Description("数据权限")]
	public const string PkgDataPermission = "admin:user:pkg:data:permission:";
}