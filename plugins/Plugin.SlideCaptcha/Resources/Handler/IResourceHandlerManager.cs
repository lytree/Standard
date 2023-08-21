using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.SlideCaptcha.Resources.Handler
{
	public interface IResourceHandlerManager
	{
		byte[] Handle(Resource resource);
	}
}
