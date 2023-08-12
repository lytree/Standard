using FreeSql;

namespace Repository.Admin;
public class ViewRepository : AdminRepositoryBase<ViewEntity>, IViewRepository
{
	public ViewRepository(UnitOfWorkManager muowm) : base(muowm)
	{
	}
}