
using FreeSql;
using Infrastructure.Repository;

namespace Repository.Admin;


/// <summary>
/// 权限库基础仓储
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class AdminRepositoryBase<TEntity> : RepositoryBase<TEntity> where TEntity : class
{
	public AdminRepositoryBase(UnitOfWorkManager uowm) : base(uowm)
	{

	}
}
