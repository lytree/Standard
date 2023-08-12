using FreeSql;

namespace Repository.Admin;
public class DictTypeRepository : AdminRepositoryBase<DictTypeEntity>, IDictTypeRepository
{
    public DictTypeRepository(UnitOfWorkManager uowm) : base(uowm)
    {
    }
}