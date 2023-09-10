using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plugin.DynamicApi;
using Plugin.DynamicApi.Attributes;
using Repository.Admin.Repository;
using Repository.Admin.Repository.OprationLog;
using Service.Admin.OprationLog.Dto;

namespace Service.Admin.OprationLog;

/// <summary>
/// 操作日志服务
/// </summary>
[Order(200)]
[DynamicApi(Area = AdminConsts.AreaName)]
public class OprationLogService : BaseService, IOprationLogService, IDynamicApi
{
	private readonly IHttpContextAccessor _context;
	private readonly IOprationLogRepository _oprationLogRepository;

	public OprationLogService(
		IHttpContextAccessor context,
		IOprationLogRepository oprationLogRepository
	)
	{
		_context = context;
		_oprationLogRepository = oprationLogRepository;
	}

	/// <summary>
	/// 查询分页
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	[HttpPost]
	public async Task<PageOutput<OprationLogListOutput>> GetPageAsync(PageInput<LogGetPageDto> input)
	{
		var userName = input.Filter?.CreatedUserName;

		var list = await _oprationLogRepository.Select
		.WhereDynamicFilter(input.DynamicFilter)
		.WhereIf(userName != null, a => a.CreatedUserName.Contains(userName))
		.Count(out var total)
		.OrderByDescending(true, c => c.Id)
		.Page(input.CurrentPage, input.PageSize)
		.ToListAsync<OprationLogListOutput>();

		var data = new PageOutput<OprationLogListOutput>()
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
	public async Task<long> AddAsync(OprationLogAddInput input)
	{
		string ua = _context.HttpContext.Request.Headers["User-Agent"];
		if (ua != null)
		{
			var client = UAParser.Parser.GetDefault().Parse(ua);
			var device = client.Device.Family;
			device = device.ToLower() == "other" ? "" : device;
			input.Browser = client.UA.Family;
			input.Os = client.OS.Family;
			input.Device = device;
			input.BrowserInfo = ua;
		}

		input.Name = User.Name;
		input.IP = GetIP(_context?.HttpContext?.Request);

		var entity = Mapper.Map<OprationLogEntity>(input);
		await _oprationLogRepository.InsertAsync(entity);

		return entity.Id;
	}
}