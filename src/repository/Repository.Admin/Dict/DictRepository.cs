using FreeSql;

namespace Repository.Admin;
public class DictRepository : AdminRepositoryBase<DictEntity>, IDictRepository
{
    public DictRepository(UnitOfWorkManager uowm) : base(uowm)
    {
    }
}