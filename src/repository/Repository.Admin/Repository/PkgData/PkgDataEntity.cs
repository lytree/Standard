
using FreeSql.DataAnnotations;
using Repository.Admin.Core;
using Repository.Admin.Repository.Pkg;
using System;
using System.Collections.Generic;


namespace Repository.Admin.Repository.PkgData;

/// <summary>
/// 套餐
/// </summary>
[Table(Name = "ad_pkg_data")]
[Index("idx_{tablename}_01", nameof(PkgId) + "," + nameof(DataId), true)]
public partial class PkgDataEntity : EntityBase
{
	/// <summary>
	/// 套餐Id
	/// </summary>
	public long PkgId { get; set; }

	/// <summary>
	/// 套餐
	/// </summary>
	public PkgEntity Pkg { get; set; }

	/// <summary>
	/// 权限Id
	/// </summary>
	public long DataId { get; set; }

	/// <summary>
	/// 权限
	/// </summary>
	public dynamic Data { get; set; }

}