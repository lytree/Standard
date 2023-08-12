using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository;

public partial class DbConfig
{
	/// <summary>
	/// 同步数据地址
	/// </summary>
	public string SyncDataPath { get; set; } = "InitData/Admin";

	/// <summary>
	/// 同步数据包含表列表
	/// </summary>
	public string[] SyncDataIncludeTables { get; set; }

	/// <summary>
	/// 同步数据排除表列表
	/// </summary>
	public string[] SyncDataExcludeTables { get; set; }
	/// <summary>
	/// 同步更新数据
	/// </summary>
	public bool SysUpdateData { get; set; } = false;
}
