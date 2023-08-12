
using FreeSql;

namespace Repository.Admin;
public class LoginLogRepository : AdminRepositoryBase<LoginLogEntity>, ILoginLogRepository
{
	public LoginLogRepository(UnitOfWorkManager uowm) : base(uowm)
	{
	}
}