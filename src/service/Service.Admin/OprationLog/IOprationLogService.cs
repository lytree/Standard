using System.Threading.Tasks;
using Infrastructure.Service;
using Repository.Admin;
using Service.Admin.OprationLog.Dto;

namespace Service.Admin.OprationLog;

/// <summary>
/// 操作日志接口
/// </summary>
public interface IOprationLogService
{
	Task<PageOutput<OprationLogListOutput>> GetPageAsync(PageInput<LogGetPageDto> input);

	Task<long> AddAsync(OprationLogAddInput input);
}