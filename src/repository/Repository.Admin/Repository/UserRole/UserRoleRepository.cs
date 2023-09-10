
using FreeSql;

namespace Repository.Admin.Repository.UserRole;
public class UserRoleRepository : AdminRepositoryBase<UserRoleEntity>, IUserRoleRepository
{
    public UserRoleRepository(UnitOfWorkManager uowm) : base(uowm)
    {

    }
}