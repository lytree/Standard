using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Host.Window;
static class ServiceExtensions
{
    /// <summary>
    /// 控制命令
    /// </summary>
    private enum Command
    {
        Start,
        Stop,
        Remove
    }


    /// <summary>
    /// 使用windows服务
    /// </summary>
    /// <param name="hostBuilder"></param> 
    /// <returns></returns>
    public static IHostBuilder UseWindowsService(this IHostBuilder hostBuilder)
    {
        return WindowsServiceLifetimeHostBuilderExtensions.UseWindowsService(hostBuilder);
    }

    /// <summary>
    /// 运行主机
    /// </summary>
    /// <param name="app"></param>
    /// <param name="singleton"></param>
    public static void Run(this WebApplication app, string appName, bool singleton)
    {
        var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger(appName);
        if (UseCommand(logger) == false)
        {
            using var mutex = new Mutex(true, "Global\\AppHost", out var firstInstance);
            if (singleton == false || firstInstance)
            {
                app.Run();
            }
            else
            {
                logger.LogWarning($"程序将自动关闭：系统已运行其它实例");
            }
        }
    }

    /// <summary>
    /// 使用命令
    /// </summary>
    /// <param name="logger"></param>
    /// <returns></returns>
    private static bool UseCommand(ILogger logger)
    {
        var args = Environment.GetCommandLineArgs();
        if (Enum.TryParse<Command>(args.Skip(1).FirstOrDefault(), true, out var cmd) == false)
        {
            return false;
        }

        var action = cmd == Command.Start ? "启动" : "停止";
        try
        {

            UseCommandAtWindows(cmd);

            logger.LogInformation("服务{action}成功", action);
        }
        catch (Exception ex)
        {
            logger.LogError("服务{action}异常 异常信息：{}", action, ex.Message);
        }
        return true;
    }

    /// <summary>
    /// 应用控制指令
    /// </summary> 
    /// <param name="cmd"></param>
    [SupportedOSPlatform("windows")]
    private static void UseCommandAtWindows(Command cmd)
    {
        var binaryPath = Environment.GetCommandLineArgs().First();
        var serviceName = Path.GetFileNameWithoutExtension(binaryPath);
        var state = true;
        if (cmd == Command.Start)
        {
            //state = ServiceInstallUtil.InstallAndStartService(serviceName, binaryPath);
        }
        else if (cmd == Command.Stop)
        {
            //state = ServiceInstallUtil.StopAndDeleteService(serviceName);
        }

        if (state == false)
        {
            throw new Win32Exception();
        }
    }
}