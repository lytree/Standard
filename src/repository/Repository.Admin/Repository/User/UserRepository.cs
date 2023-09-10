
using FreeSql;

namespace Repository.Admin.Repository.User;
public class UserRepository : AdminRepositoryBase<UserEntity>, IUserRepository
{
    public UserRepository(UnitOfWorkManager muowm) : base(muowm)
    {

    }
}