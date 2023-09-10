using FreeSql;

namespace Repository.Admin.Repository.Permission;
public class PermissionRepository : AdminRepositoryBase<PermissionEntity>, IPermissionRepository
{
    public PermissionRepository(UnitOfWorkManager uowm) : base(uowm)
    {
    }
}