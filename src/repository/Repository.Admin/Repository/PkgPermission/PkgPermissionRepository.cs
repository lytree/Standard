

using FreeSql;
using Repository.Admin;
using Repository.Admin.Repository.PkgPermission;

namespace ZhonTai.Admin.Repositories;

public class PkgPermissionRepository : AdminRepositoryBase<PkgPermissionEntity>, IPkgPermissionRepository
{
    public PkgPermissionRepository(UnitOfWorkManager uowm) : base(uowm)
    {

    }
}