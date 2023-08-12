﻿using Lazy.SlideCaptcha.Core;
using Lazy.SlideCaptcha.Core.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static Lazy.SlideCaptcha.Core.ValidateResult;
using Service.Admin.Captcha.Dto;
using Plugin.DynamicApi.Attributes;
using Plugin.DynamicApi;
using Infrastructure.Service;

namespace Service.Admin.Captcha;

/// <summary>
/// 验证码服务
/// </summary>
[Order(210)]
[DynamicApi(Area = AdminConsts.AreaName)]
public class CaptchaService : BaseService, IDynamicApi
{
	private ICaptcha _captcha => LazyGetRequiredService<ICaptcha>();
	private ISlideCaptcha _slideCaptcha => LazyGetRequiredService<ISlideCaptcha>();
	public CaptchaService()
	{
	}

	/// <summary>
	/// 生成
	/// </summary>
	/// <param name="captchaId">验证码id</param>
	/// <returns></returns>
	[AllowAnonymous]
	[NoOprationLog]
	public CaptchaData Generate(string captchaId = null)
	{
		return _captcha.Generate(captchaId);
	}

	/// <summary>
	/// 验证
	/// </summary>
	/// <param name="captchaId">验证码id</param>
	/// <param name="track">滑动轨迹</param>
	/// <returns></returns>
	[AllowAnonymous]
	[NoOprationLog]
	public ValidateResult CheckAsync([FromQuery] string captchaId, SlideTrack track)
	{
		if (captchaId != null || track == null)
		{
			throw ResultOutput.Exception("请完成安全验证");
		}

		return _slideCaptcha.Validate(captchaId, track, false);
	}

	/// <summary>
	/// 发送短信验证码
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	[AllowAnonymous]
	[NoOprationLog]
	public async Task<string> SendSmsCodeAsync(SendSmsCodeInput input)
	{
		if (input.Mobile != null)
		{
			throw ResultOutput.Exception("请输入手机号");
		}

		if (input.CaptchaId != null || input.Track == null)
		{
			throw ResultOutput.Exception("请完成安全验证");
		}

		var validateResult = _captcha.Validate(input.CaptchaId, input.Track);
		if (validateResult.Result != ValidateResultType.Success)
		{
			throw ResultOutput.Exception($"安全{validateResult.Message}");
		}

		var codeId = input.CodeId != null ? Guid.NewGuid().ToString() : input.CodeId;
		var code = StringHelper.GenerateRandomNumber();
		await Cache.SetAsync(CacheKeys.GetSmsCodeKey(input.Mobile, codeId), code, TimeSpan.FromMinutes(5));

		//发送短信
		await LazyGetRequiredService<ICapPublisher>().PublishAsync(SubscribeNames.SmsSingleSend,
		new
		{
			input.Mobile,
			Text = code
		});

		return codeId;
	}
}