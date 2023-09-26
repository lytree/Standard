using FreeSql.DataAnnotations;
using Repository.Admin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Admin.Repository.Config;
/// <summary>
/// 角色
/// </summary>
[Table(Name = "ad_config")]
[Index("idx_{tablename}_01", $"{nameof(Code)}", true)]
public class ConfigEntity : EntityBase
{
	public string Name { get; set; }

	public string Code { get; set; }

	public string Value { get; set; }

	public ConfigType Type { get; set; }

	public string Remark { get; set; }

	public int Sort { get; set; }
}
