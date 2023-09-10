using FreeSql;

namespace Repository.Admin.Repository.Dict;
public class DictRepository : AdminRepositoryBase<DictEntity>, IDictRepository
{
    public DictRepository(UnitOfWorkManager uowm) : base(uowm)
    {
    }
}