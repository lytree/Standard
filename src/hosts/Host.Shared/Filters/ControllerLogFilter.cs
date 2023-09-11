
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Host.Shared.Filters;

/// <summary>
/// 控制器操作日志记录
/// </summary>
public class ControllerLogFilter : IAsyncActionFilter
{
    private readonly ILogHandler _logHandler;

    public ControllerLogFilter(ILogHandler logHandler)
    {
        _logHandler = logHandler;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.HttpContext.Items["_ActionArguments"] = context.ActionArguments;

        if (context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(NoOprationLogAttribute)))
        {
            await next();
            return;
        }

        await _logHandler.LogAsync(context, next);
    }
}
