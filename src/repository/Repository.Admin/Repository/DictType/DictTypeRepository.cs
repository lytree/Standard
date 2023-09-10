using FreeSql;

namespace Repository.Admin.Repository.DictType;
public class DictTypeRepository : AdminRepositoryBase<DictTypeEntity>, IDictTypeRepository
{
    public DictTypeRepository(UnitOfWorkManager uowm) : base(uowm)
    {
    }
}