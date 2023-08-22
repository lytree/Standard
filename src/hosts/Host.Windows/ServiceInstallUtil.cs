﻿using System.Runtime.Versioning;
namespace Host.BackServer;


internal static class ServiceInstallUtil
{
	///// <summary>
	///// 安装并启动服务
	///// </summary>
	///// <param name="serviceName"></param>
	///// <param name="binaryPath"></param>
	///// <param name="startType"></param>
	///// <returns></returns>
	//[SupportedOSPlatform("windows")]
	//public static bool InstallAndStartService(string serviceName, string binaryPath, ServiceStartType startType = ServiceStartType.SERVICE_AUTO_START)
	//{
	//	using var hSCManager = OpenSCManager(null, null, ServiceManagerAccess.SC_MANAGER_ALL_ACCESS);
	//	if (hSCManager.IsInvalid == true)
	//	{
	//		return false;
	//	}

	//	var hService = OpenService(hSCManager, serviceName, ServiceAccess.SERVICE_ALL_ACCESS);
	//	if (hService.IsInvalid == true)
	//	{
	//		hService = CreateService(
	//			hSCManager,
	//			serviceName,
	//			serviceName,
	//			ServiceAccess.SERVICE_ALL_ACCESS,
	//			ServiceType.SERVICE_WIN32_OWN_PROCESS,
	//			startType,
	//			ServiceErrorControl.SERVICE_ERROR_NORMAL,
	//			Path.GetFullPath(binaryPath),
	//			lpLoadOrderGroup: null,
	//			lpdwTagId: 0,
	//			lpDependencies: null,
	//			lpServiceStartName: null,
	//			lpPassword: null);
	//	}

	//	if (hService.IsInvalid == true)
	//	{
	//		return false;
	//	}

	//	using (hService)
	//	{
	//		return PInvoke.StartService(hService, 0, null);
	//	}
	//}

	///// <summary>
	///// 停止并删除服务
	///// </summary>
	///// <param name="serviceName"></param>
	///// <returns></returns>
	//[SupportedOSPlatform("windows")]
	//public static bool StopAndDeleteService(string serviceName)
	//{
	//	using var hSCManager = OpenSCManager(null, null, ServiceManagerAccess.SC_MANAGER_ALL_ACCESS);
	//	if (hSCManager.IsInvalid == true)
	//	{
	//		return false;
	//	}

	//	using var hService = OpenService(hSCManager, serviceName, ServiceAccess.SERVICE_ALL_ACCESS);
	//	if (hService.IsInvalid == true)
	//	{
	//		return true;
	//	}

	//	var status = new SERVICE_STATUS();
	//	if (QueryServiceStatus(hService, ref status) == true)
	//	{
	//		if (status.dwCurrentState != ServiceState.SERVICE_STOP_PENDING &&
	//			status.dwCurrentState != ServiceState.SERVICE_STOPPED)
	//		{
	//			ControlService(hService, ServiceControl.SERVICE_CONTROL_STOP, ref status);
	//		}
	//	}

	//	return DeleteService(hService);
	//}
}