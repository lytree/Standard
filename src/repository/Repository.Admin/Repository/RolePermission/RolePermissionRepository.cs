
using FreeSql;

namespace Repository.Admin.Repository.RolePermission;
public class RolePermissionRepository : AdminRepositoryBase<RolePermissionEntity>, IRolePermissionRepository
{
    public RolePermissionRepository(UnitOfWorkManager uowm) : base(uowm)
    {

    }
}