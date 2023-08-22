using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service;

public partial class AppConfig
{
	/// <summary>
	/// 默认密码
	/// </summary>
	public string DefaultPassword { get; set; } = "111111";

	/// <summary>
	/// 实现标准标识密码哈希
	/// </summary>
	public bool PasswordHasher { get; set; } = false;

	/// <summary>
	/// 验证码配置
	/// </summary>
	public VarifyCodeConfig VarifyCode { get; set; } = new VarifyCodeConfig();
	/// <summary>
	/// 程序集名称
	/// </summary>
	public string[] AssemblyNames { get; set; }
}
/// <summary>
/// 验证码配置
/// </summary>
public class VarifyCodeConfig
{
	/// <summary>
	/// 启用
	/// </summary>
	public bool Enable { get; set; } = true;

	/// <summary>
	/// 操作日志
	/// </summary>
	public string[] Fonts { get; set; }// = new[] { "Times New Roman", "Verdana", "Arial", "Gungsuh", "Impact" };
}