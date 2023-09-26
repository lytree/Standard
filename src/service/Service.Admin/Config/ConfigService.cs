using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plugin.DynamicApi;
using Plugin.DynamicApi.Attributes;
using Repository.Admin.Repository.Config;
using Repository.Admin.Repository.Dict.Dto;
using Service.Admin.Config.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin.Config;
/// <summary>
/// 系统设置服务
/// </summary>
[Order(60)]
[DynamicApi(Area = AdminConsts.AreaName)]
public class ConfigService : BaseService, IConfigService, IDynamicApi
{
	private readonly IConfigRepository _configRepository;

	public ConfigService(IConfigRepository configRepository)
	{
		_configRepository = configRepository;
	}

	/// <summary>
	/// 查询
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task<ConfigGetOutput> GetAsync(long id)
	{
		var result = await _configRepository.GetAsync<ConfigGetOutput>(id);
		return result;
	}

	/// <summary>
	/// 查询分页
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	[HttpPost]
	public async Task<PageOutput<ConfigGetPageOutput>> GetPageAsync(PageInput<ConfigGetPageDto> input)
	{
		var key = input.Filter?.Name;
		var list = await _configRepository.Select
		.WhereDynamicFilter(input.DynamicFilter)
		.WhereIf(key != null, a => a.Name.Contains(key) || a.Code.Contains(key))
		.Count(out var total)
		.OrderByDescending(a => a.Sort)
		.Page(input.CurrentPage, input.PageSize)
		.ToListAsync<ConfigGetPageOutput>();

		var data = new PageOutput<ConfigGetPageOutput>()
		{
			List = list,
			Total = total
		};

		return data;
	}

	/// <summary>
	/// 新增
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public async Task<long> AddAsync(ConfigAddInput input)
	{
		if (await _configRepository.Select.AnyAsync(a => a.Name == input.Name))
		{
			throw ResultOutput.Exception($"配置项已存在");
		}

		if (input.Code != null && await _configRepository.Select.AnyAsync(a => a.Code == input.Code))
		{
			throw ResultOutput.Exception($"配置项编码已存在");
		}

		var entity = Mapper.Map<ConfigEntity>(input);
		if (entity.Sort == 0)
		{
			var sort = await _configRepository.Select.MaxAsync(a => a.Sort);
			entity.Sort = sort + 1;
		}
		await _configRepository.InsertAsync(entity);
		return entity.Id;
	}

	/// <summary>
	/// 修改
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public async Task UpdateAsync(ConfigUpdateInput input)
	{
		var entity = await _configRepository.GetAsync(input.Id);
		if (!(entity?.Id > 0))
		{
			throw ResultOutput.Exception("配置项不存在");
		}

		if (await _configRepository.Select.AnyAsync(a => a.Id != input.Id && a.Name == input.Name))
		{
			throw ResultOutput.Exception($"配置项已存在");
		}

		if (input.Code != null && await _configRepository.Select.AnyAsync(a => a.Id != input.Id && a.Code == input.Code))
		{
			throw ResultOutput.Exception($"配置项编码已存在");
		}
		Mapper.Map(input, entity);
		await _configRepository.UpdateAsync(entity);
	}

	/// <summary>
	/// 彻底删除
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task DeleteAsync(long id)
	{
		await _configRepository.DeleteAsync(m => m.Id == id);
	}

	/// <summary>
	/// 批量彻底删除
	/// </summary>
	/// <param name="ids"></param>
	/// <returns></returns>
	public async Task BatchDeleteAsync(long[] ids)
	{
		await _configRepository.DeleteAsync(a => ids.Contains(a.Id));
	}

	/// <summary>
	/// 删除
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task SoftDeleteAsync(long id)
	{
		await _configRepository.SoftDeleteAsync(id);
	}

	/// <summary>
	/// 批量删除
	/// </summary>
	/// <param name="ids"></param>
	/// <returns></returns>
	public async Task BatchSoftDeleteAsync(long[] ids)
	{
		await _configRepository.SoftDeleteAsync(ids);
	}
}
