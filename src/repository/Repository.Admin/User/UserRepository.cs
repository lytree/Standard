
using FreeSql;

namespace Repository.Admin;
public class UserRepository : AdminRepositoryBase<UserEntity>, IUserRepository
{
	public UserRepository(UnitOfWorkManager muowm) : base(muowm)
	{

	}
}