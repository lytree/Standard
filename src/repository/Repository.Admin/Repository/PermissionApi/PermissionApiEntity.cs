
using FreeSql.DataAnnotations;
using Repository.Admin.Core;
using Repository.Admin.Repository.Api;
using Repository.Admin.Repository.Permission;

namespace Repository.Admin.Repository.PermissionApi;
/// <summary>
/// 权限接口
/// </summary>
[Table(Name = "ad_permission_api")]
[Index("idx_{tablename}_01", nameof(PermissionId) + "," + nameof(ApiId), true)]
public class PermissionApiEntity : EntityAdd
{
    /// <summary>
    /// 权限Id
    /// </summary>
    public long PermissionId { get; set; }

    /// <summary>
    /// 权限
    /// </summary>
    [NotGen]
    public PermissionEntity Permission { get; set; }

    /// <summary>
    /// 接口Id
    /// </summary>
    public long ApiId { get; set; }

    /// <summary>
    /// 接口
    /// </summary>
    [NotGen]
    public ApiEntity Api { get; set; }
}