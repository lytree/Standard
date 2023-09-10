
using FreeSql;

namespace Repository.Admin.Repository.OprationLog;
public class OprationLogRepository : AdminRepositoryBase<OprationLogEntity>, IOprationLogRepository
{
    public OprationLogRepository(UnitOfWorkManager uowm) : base(uowm)
    {
    }
}