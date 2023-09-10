
using FreeSql;

namespace Repository.Admin.Repository.PermissionApi;
public class PermissionApiRepository : AdminRepositoryBase<PermissionApiEntity>, IPermissionApiRepository
{
    public PermissionApiRepository(UnitOfWorkManager uowm) : base(uowm)
    {

    }
}