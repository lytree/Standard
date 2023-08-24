using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Window;

sealed class AppHostedService : BackgroundService
{
    /// <summary>
    /// 状态：0-默认状态，1-正在完成关闭前的必要工作，2-正在执行 StopAsync
    /// </summary>
    private volatile int _status = 0; //状态
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly ILogger<AppHostedService> _logger;

    public AppHostedService(IHostApplicationLifetime hostApplicationLifetime, ILogger<AppHostedService> logger)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        // 注册应用停止前需要完成的操作
        _hostApplicationLifetime.ApplicationStopping.Register(() =>
        {

        });

        _logger.LogInformation("上班了，又是精神抖擞的一天，output from StartAsync");
        return base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            // 这里实现实际的业务逻辑
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    await SomeMethodThatDoesTheWork(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Global exception occurred. Will resume in a moment.");
                }

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
        finally
        {
            _logger.LogWarning("My worker service shut down.");
        }
    }

    private async Task SomeMethodThatDoesTheWork(CancellationToken cancellationToken)
    {
        string msg = _status switch
        {
            1 => "正在完成关闭前的必要工作……",
            2 => "假装还在埋头苦干ing…… 其实我去洗杯子了",
            _ => "我爱工作，埋头苦干ing……"
        };

        _logger.LogInformation(msg);
        await Task.CompletedTask;
    }


    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _status = 2;

        _logger.LogInformation("准备下班了，output from StopAsync at: {time}", DateTimeOffset.Now);

        _logger.LogInformation("去洗洗茶杯先……", DateTimeOffset.Now);
        Task.Delay(30_000).Wait();
        _logger.LogInformation("茶杯洗好了。", DateTimeOffset.Now);

        _logger.LogInformation("下班喽 ^_^", DateTimeOffset.Now);

        return base.StopAsync(cancellationToken);
    }
}
