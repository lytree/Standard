﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.SlideCaptcha.Validator
{
	/// <summary>
	/// 仅使用BaseValidator的位置校验
	/// </summary>
	public class SimpleValidator : BaseValidator, IValidator
	{
		public override bool ValidateCore(SlideTrack slideTrack, CaptchaValidateData captchaValidateData)
		{
			return true;
		}
	}
}
