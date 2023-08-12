using FreeSql;

namespace Repository.Admin;
public class PermissionRepository : AdminRepositoryBase<PermissionEntity>, IPermissionRepository
{
	public PermissionRepository(UnitOfWorkManager uowm) : base(uowm)
	{
	}
}