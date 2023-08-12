
using FreeSql;

namespace Repository.Admin;
public class OprationLogRepository : AdminRepositoryBase<OprationLogEntity>, IOprationLogRepository
{
	public OprationLogRepository(UnitOfWorkManager uowm) : base(uowm)
	{
	}
}