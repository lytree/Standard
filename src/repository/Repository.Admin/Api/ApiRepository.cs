using FreeSql;

namespace Repository.Admin;
public class ApiRepository : AdminRepositoryBase<ApiEntity>, IApiRepository
{
	public ApiRepository(UnitOfWorkManager  uowm) : base(uowm)
	{
	}
}