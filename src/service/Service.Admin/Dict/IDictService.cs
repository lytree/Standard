
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Service;
using Repository.Admin.Repository.Dict.Dto;
using Service.Admin.Dict.Dto;

namespace Service.Admin.Dict;

/// <summary>
/// 数据字典接口
/// </summary>
public partial interface IDictService
{
	Task<DictGetOutput> GetAsync(long id);

	Task<PageOutput<DictGetPageOutput>> GetPageAsync(PageInput<DictGetPageDto> input);

	Task<long> AddAsync(DictAddInput input);

	Task UpdateAsync(DictUpdateInput input);

	Task DeleteAsync(long id);

	Task BatchDeleteAsync(long[] ids);

	Task SoftDeleteAsync(long id);

	Task BatchSoftDeleteAsync(long[] ids);
}