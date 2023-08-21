using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.SlideCaptcha.Generator
{
	public interface ICaptchaImageGenerator
	{
		CaptchaImageData Generate();
	}
}
