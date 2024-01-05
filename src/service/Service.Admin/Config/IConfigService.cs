using Infrastructure;
using Repository.Admin.Repository.Dict.Dto;
using Service.Admin.Config.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin.Config;

public partial interface IConfigService
{
	Task<ConfigGetOutput> GetAsync(long id);

	Task<PageOutput<ConfigGetPageOutput>> GetPageAsync(PageInput<ConfigGetPageDto> input);

	Task<long> AddAsync(ConfigAddInput input);

	Task UpdateAsync(ConfigUpdateInput input);

	Task DeleteAsync(long id);

	Task BatchDeleteAsync(long[] ids);

	Task SoftDeleteAsync(long id);

	Task BatchSoftDeleteAsync(long[] ids);
}
