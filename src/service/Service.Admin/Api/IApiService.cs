
using System.Threading.Tasks;

using System.Collections.Generic;
using Service.Admin.Api.Dto;
using Infrastructure.Service;
using Repository.Admin.Repository.Api;
using Repository.Admin.Repository.Api.Dto;
using Infrastructure;

namespace Service.Admin.Api;

/// <summary>
/// api接口
/// </summary>
public interface IApiService
{
	Task<ApiGetOutput> GetAsync(long id);

	Task<List<ApiListOutput>> GetListAsync(string key);

	Task<PageOutput<ApiEntity>> GetPageAsync(Admin.PageInput<ApiGetPageDto> input);

	Task<long> AddAsync(ApiAddInput input);

	Task UpdateAsync(ApiUpdateInput input);

	Task DeleteAsync(long id);

	Task BatchDeleteAsync(long[] ids);

	Task SoftDeleteAsync(long id);

	Task BatchSoftDeleteAsync(long[] ids);

	Task SyncAsync(ApiSyncInput input);
}