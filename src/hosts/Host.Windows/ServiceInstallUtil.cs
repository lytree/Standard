using System.Runtime.Versioning;
using static Host.BackServer.AdvApi32;

namespace Host.BackServer;


internal static class ServiceInstallUtil
{
	/// <summary>
	/// 安装并启动服务
	/// </summary>
	/// <param name="serviceName"></param>
	/// <param name="binaryPath"></param>
	/// <param name="startType"></param>
	/// <returns></returns>
	[SupportedOSPlatform("windows")]
	public static bool InstallAndStartService(string serviceName, string binaryPath)
	{
		var hSCManager = Windows.Win32.PInvoke.OpenSCManager("", "", ServiceManagerAccess.SC_MANAGER_ALL_ACCESS);
		if (hSCManager.IsInvalid)
		{
			return false;
		}

		var hService = Windows.Win32.PInvoke.OpenService(hSCManager, serviceName, ServiceAccess.SERVICE_ALL_ACCESS);
		if (hService.IsInvalid)
		{
			hService = Windows.Win32.PInvoke.CreateService(
				hSCManager,
				serviceName,
				serviceName,
				ServiceAccess.SERVICE_ALL_ACCESS,
				ServiceType.SERVICE_WIN32_OWN_PROCESS,
				0x00000002,
				ServiceErrorControl.SERVICE_ERROR_NORMAL,
				Path.GetFullPath(binaryPath),
				lpLoadOrderGroup: null,
				lpdwTagId: 0,
				lpDependencies: null,
				lpServiceStartName: null,
				lpPassword: null);
		}

		if (hService.IsInvalid == true)
		{
			return false;
		}

		using (hService)
		{
			return Windows.Win32.PInvoke.StartService(hService, 0, null);
		}
	}

	/// <summary>
	/// 停止并删除服务
	/// </summary>
	/// <param name="serviceName"></param>
	/// <returns></returns>
	[SupportedOSPlatform("windows")]
	public static bool StopAndDeleteService(string serviceName)
	{
		var hSCManager = Windows.Win32.PInvoke.OpenSCManager(null, null, (uint)(0x000F0000 | 0x0001 | 0x0002 | 0x0004 | 0x0008 | 0x0010 | 0x0020));
		if (hSCManager.IsInvalid)
		{
			return false;
		}

		var hService = Windows.Win32.PInvoke.OpenService(hSCManager, serviceName, ServiceAccess.SERVICE_ALL_ACCESS);
		if (hService.IsInvalid == true)
		{
			return true;
		}

		var status = new SERVICE_STATUS();
		if (Windows.Win32.PInvoke.QueryServiceStatus(hService, ref status) == true)
		{
			if (status.dwCurrentState != ServiceState.SERVICE_STOP_PENDING &&
				status.dwCurrentState != ServiceState.SERVICE_STOPPED)
			{
				Windows.Win32.PInvoke.ControlService(hService, ServiceControl.SERVICE_CONTROL_STOP, ref status);
			}
		}

		return Windows.Win32.PInvoke.DeleteService(hService);
	}
}