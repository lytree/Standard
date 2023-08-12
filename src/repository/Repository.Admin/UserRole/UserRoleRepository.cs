
using FreeSql;

namespace Repository.Admin;
public class UserRoleRepository : AdminRepositoryBase<UserRoleEntity>, IUserRoleRepository
{
	public UserRoleRepository(UnitOfWorkManager uowm) : base(uowm)
	{

	}
}