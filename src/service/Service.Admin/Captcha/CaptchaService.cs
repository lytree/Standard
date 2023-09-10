using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Plugin.DynamicApi.Attributes;
using Plugin.DynamicApi;
using Infrastructure.Service;
using Plugin.SlideCaptcha;
using Plugin.SlideCaptcha.Validator;
using static Plugin.SlideCaptcha.ValidateResult;
using Infrastructure;

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

}