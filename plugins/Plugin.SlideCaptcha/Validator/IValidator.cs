using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.SlideCaptcha.Validator
{
	public interface IValidator
	{
		bool Validate(SlideTrack slideTrack, CaptchaValidateData captchaValidateData);
	}
}
