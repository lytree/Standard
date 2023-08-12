
using FreeSql;

namespace Repository.Admin;
public class PermissionApiRepository : AdminRepositoryBase<PermissionApiEntity>, IPermissionApiRepository
{
	public PermissionApiRepository(UnitOfWorkManager uowm) : base(uowm)
	{

	}
}