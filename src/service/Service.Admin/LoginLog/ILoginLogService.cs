﻿
using System.Threading.Tasks;
using Infrastructure.Service;
using Repository.Admin;
using Service.Admin.LoginLog.Dto;

namespace Service.Admin.LoginLog;

/// <summary>
/// 登录日志接口
/// </summary>
public interface ILoginLogService
{
	Task<PageOutput<LoginLogListOutput>> GetPageAsync(PageInput<LogGetPageDto> input);

	Task<long> AddAsync(LoginLogAddInput input);
}