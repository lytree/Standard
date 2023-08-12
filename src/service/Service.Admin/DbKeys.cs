using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin;

/// <summary>
/// 数据库键名
/// </summary>
public partial class DbKeys
{
	/// <summary>
	/// 数据库注册键
	/// </summary>
	[Description("数据库注册键")]
	public static string AdminDb { get; set; } = "admindb";
}
