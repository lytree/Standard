
using FreeSql;

namespace Repository.Admin.Repository.LoginLog;
public class LoginLogRepository : AdminRepositoryBase<LoginLogEntity>, ILoginLogRepository
{
    public LoginLogRepository(UnitOfWorkManager uowm) : base(uowm)
    {
    }
}