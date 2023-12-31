﻿using Microsoft.Extensions.Hosting;
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

namespace Host.BackServer;
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

	[SupportedOSPlatform("linux")]
	[DllImport("libc", SetLastError = true)]
	private static extern uint geteuid();


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
			UseCommandAtLinux(cmd);
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
	[SupportedOSPlatform("linux")]
	private static void UseCommandAtLinux(Command cmd)
	{
		if (geteuid() != 0)
		{
			throw new UnauthorizedAccessException("无法操作服务：没有root权限");
		}

		var binaryPath = Path.GetFullPath(Environment.GetCommandLineArgs().First());
		var serviceName = Path.GetFileNameWithoutExtension(binaryPath);
		var serviceFilePath = $"/etc/systemd/system/{serviceName}.service";

		if (cmd == Command.Start)
		{
			var serviceBuilder = new StringBuilder()
				.AppendLine("[Unit]")
				.AppendLine($"Description={serviceName}")
				.AppendLine()
				.AppendLine("[Service]")
				.AppendLine("Type=notify")
				.AppendLine($"User={Environment.UserName}")
				.AppendLine($"ExecStart={binaryPath}")
				.AppendLine($"WorkingDirectory={Path.GetDirectoryName(binaryPath)}")
				.AppendLine()
				.AppendLine("[Install]")
				.AppendLine("WantedBy=multi-user.target");
			File.WriteAllText(serviceFilePath, serviceBuilder.ToString());

			Process.Start("chcon", $"--type=bin_t {binaryPath}").WaitForExit(); // SELinux
			Process.Start("systemctl", "daemon-reload").WaitForExit();
			Process.Start("systemctl", $"start {serviceName}.service").WaitForExit();
			Process.Start("systemctl", $"enable {serviceName}.service").WaitForExit();
		}
		else if (cmd == Command.Stop)
		{
			Process.Start("systemctl", $"stop {serviceName}.service").WaitForExit();
			Process.Start("systemctl", $"disable {serviceName}.service").WaitForExit();

			if (File.Exists(serviceFilePath))
			{
				File.Delete(serviceFilePath);
			}
			Process.Start("systemctl", "daemon-reload").WaitForExit();
		}
	}
}