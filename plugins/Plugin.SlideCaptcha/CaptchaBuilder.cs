﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.SlideCaptcha
{
	public class CaptchaBuilder
	{
		public IServiceCollection Services { get; set; }

		public CaptchaBuilder(IServiceCollection serviceCollection)
		{
			Services = serviceCollection;
		}
	}
}
