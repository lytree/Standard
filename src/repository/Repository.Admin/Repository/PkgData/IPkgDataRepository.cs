using Repository.Admin.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Admin.Repository.PkgData;

public interface IPkgDataRepository : IRepositoryBase<PkgDataEntity>
{
    /// <summary>
    /// 获得本套餐和下级套餐Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<List<long>> GetChildIdListAsync(long id);

    /// <summary>
    /// 获得当前套餐和下级套餐Id
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<List<long>> GetChildIdListAsync(long[] ids);
}