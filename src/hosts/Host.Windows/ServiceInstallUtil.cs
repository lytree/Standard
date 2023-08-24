using System.Runtime.Versioning;
using System.ServiceProcess;

namespace Host.Window;
#pragma warning disable CA1416 // 验证平台兼容性

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
    public static unsafe bool InstallAndStartService(string serviceName, string binaryPath, uint lpdwTagId = 0)
    {
        var hSCManager = Windows.Win32.PInvoke.OpenSCManager(new Windows.Win32.Foundation.PCWSTR(null), new Windows.Win32.Foundation.PCWSTR(null), 0xF003F);
        if (hSCManager == IntPtr.Zero)
        {
            return false;
        }

        var hService = Windows.Win32.PInvoke.OpenService(hSCManager, serviceName, 0xF01FF);
        if (hService == IntPtr.Zero)
        {

            hService = Windows.Win32.PInvoke.CreateService(
                hSCManager,
                serviceName,
                serviceName,
                0xF01FF,
                Windows.Win32.System.Services.ENUM_SERVICE_TYPE.SERVICE_WIN32_OWN_PROCESS,
                Windows.Win32.System.Services.SERVICE_START_TYPE.SERVICE_AUTO_START,
                Windows.Win32.System.Services.SERVICE_ERROR.SERVICE_ERROR_NORMAL,
                Path.GetFullPath(binaryPath),
                lpLoadOrderGroup: null,
                lpdwTagId: &lpdwTagId,
                lpDependencies: null,
                lpServiceStartName: null,
                lpPassword: null);

        }

        if (hService == IntPtr.Zero)
        {
            return false;
        }

        return Windows.Win32.PInvoke.StartService(hService, 0, null);
    }

    /// <summary>
    /// 停止服务
    /// </summary>
    /// <param name="serviceName"></param>
    /// <returns></returns>
    [SupportedOSPlatform("windows")]
    public static unsafe bool StopService(string serviceName)
    {
        var hSCManager = Windows.Win32.PInvoke.OpenSCManager(new Windows.Win32.Foundation.PCWSTR(null), new Windows.Win32.Foundation.PCWSTR(null), 0xF003F);
        if (hSCManager == IntPtr.Zero)
        {
            return false;
        }

        var hService = Windows.Win32.PInvoke.OpenService(hSCManager, serviceName, 0xF01FF);
        if (hService == IntPtr.Zero)
        {
            return true;
        }


        if (Windows.Win32.PInvoke.QueryServiceStatus(hService, out var status) == true)
        {
            if (status.dwCurrentState != Windows.Win32.System.Services.SERVICE_STATUS_CURRENT_STATE.SERVICE_STOP_PENDING &&
                status.dwCurrentState != Windows.Win32.System.Services.SERVICE_STATUS_CURRENT_STATE.SERVICE_STOPPED)
            {
                Windows.Win32.PInvoke.ControlService(hService, 0x00000001, out status);
                return status.dwCurrentState == Windows.Win32.System.Services.SERVICE_STATUS_CURRENT_STATE.SERVICE_STOP_PENDING|| status.dwCurrentState == Windows.Win32.System.Services.SERVICE_STATUS_CURRENT_STATE.SERVICE_STOPPED;
            }
        }
        return false;
        
    }
    /// <summary>
    /// 删除服务
    /// </summary>
    /// <param name="serviceName"></param>
    /// <returns></returns>
    [SupportedOSPlatform("windows")]
    public static unsafe bool DeleteService(string serviceName)
    {
        var hSCManager = Windows.Win32.PInvoke.OpenSCManager(new Windows.Win32.Foundation.PCWSTR(null), new Windows.Win32.Foundation.PCWSTR(null), 0xF003F);
        if (hSCManager == IntPtr.Zero)
        {
            return false;
        }

        var hService = Windows.Win32.PInvoke.OpenService(hSCManager, serviceName, 0xF01FF);
        if (hService == IntPtr.Zero)
        {
            return true;
        }

        return Windows.Win32.PInvoke.DeleteService(hService);
    }

}
#pragma warning restore CA1416 // 验证平台兼容性