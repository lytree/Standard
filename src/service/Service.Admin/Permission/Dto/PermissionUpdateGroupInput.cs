using System.ComponentModel.DataAnnotations;
using Infrastructure.Service;

namespace Service.Admin.Permission.Dto;

public class PermissionUpdateGroupInput : PermissionAddGroupInput
{
	/// <summary>
	/// 权限Id
	/// </summary>
	[Required]
	[ValidateRequired("请选择分组")]
	public long Id { get; set; }
}