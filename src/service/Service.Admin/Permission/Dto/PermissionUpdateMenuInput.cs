using System.ComponentModel.DataAnnotations;
using Infrastructure.Service;

namespace Service.Admin.Permission.Dto;

public class PermissionUpdateMenuInput : PermissionAddMenuInput
{
	/// <summary>
	/// 权限Id
	/// </summary>
	[Required]
	[ValidateRequired("请选择菜单")]
	public long Id { get; set; }
}