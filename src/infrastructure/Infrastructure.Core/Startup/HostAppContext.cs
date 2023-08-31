using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Startup
{
	public class HostAppContext
	{
		/// <summary>
		/// 服务
		/// </summary>
		public IServiceCollection Services { get; set; }

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
