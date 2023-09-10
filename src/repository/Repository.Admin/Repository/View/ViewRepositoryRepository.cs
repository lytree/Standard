using FreeSql;

namespace Repository.Admin.Repository.View;
public class ViewRepository : AdminRepositoryBase<ViewEntity>, IViewRepository
{
    public ViewRepository(UnitOfWorkManager muowm) : base(muowm)
    {
    }
}