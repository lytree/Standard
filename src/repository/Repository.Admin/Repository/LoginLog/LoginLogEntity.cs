using FreeSql.DataAnnotations;

namespace Repository.Admin.Repository;
/// <summary>
/// 登录日志
/// </summary>
[Table(Name = "ad_login_log")]
public partial class LoginLogEntity : LogAbstract
{
}