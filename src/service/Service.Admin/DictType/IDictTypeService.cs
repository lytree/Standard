
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Service;
using Repository.Admin.Repository.DictType.Dto;
using Service.Admin.DictType.Dto;

namespace Service.Admin.DictType;

/// <summary>
/// 数据字典类型接口
/// </summary>
public partial interface IDictTypeService
{
	Task<DictTypeGetOutput> GetAsync(long id);

	Task<PageOutput<DictTypeGetPageOutput>> GetPageAsync(PageInput<DictTypeGetPageDto> input);

	Task<long> AddAsync(DictTypeAddInput input);

	Task UpdateAsync(DictTypeUpdateInput input);

	Task DeleteAsync(long id);

	Task BatchDeleteAsync(long[] ids);

	Task SoftDeleteAsync(long id);

	Task BatchSoftDeleteAsync(long[] ids);
}