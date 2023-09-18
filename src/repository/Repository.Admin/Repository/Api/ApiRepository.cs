using FreeSql;

namespace Repository.Admin.Repository.Api;
public class ApiRepository : AdminRepositoryBase<ApiEntity>, IApiRepository
{
	public ApiRepository(UnitOfWorkManager uowm) : base(uowm)
	{
	}
}