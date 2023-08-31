using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Startup
{
	public class HostAppMiddlewareContext
	{
		/// <summary>
		/// 应用
		/// </summary>
		public WebApplication App { get; set; }

		/// <summary>
		/// 环境
		/// </summary>
		public IHostEnvironment Environment { get; set; }

		/// <summary>
		/// 配置
		/// </summary>
		public IConfiguration Configuration { get; set; }
	}
}
