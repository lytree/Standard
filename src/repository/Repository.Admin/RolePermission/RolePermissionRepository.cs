
using FreeSql;

namespace Repository.Admin;
public class RolePermissionRepository : AdminRepositoryBase<RolePermissionEntity>, IRolePermissionRepository
{
	public RolePermissionRepository(UnitOfWorkManager uowm) : base(uowm)
	{

	}
}