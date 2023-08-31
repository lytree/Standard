using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Admin;

/// <summary>
/// 数据库键名
/// </summary>
public static class DbKeys
{
	/// <summary>
	/// 数据库注册键
	/// </summary>
	[Description("管理平台库名")]
	public static string AdminDb { get; set; } = "admindb";
}
