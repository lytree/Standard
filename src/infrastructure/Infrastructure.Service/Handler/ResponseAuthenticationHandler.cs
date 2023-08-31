using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Infrastructure.Service.Handler;


/// <summary>
/// 响应认证处理器
/// </summary>
public class ResponseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public ResponseAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
    ) : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        throw new NotImplementedException();
    }

    protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        Response.ContentType = "application/json";
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        await Response.WriteAsync(JsonHelper.Serialize(
            new ResponseStatusData
            {
                Code = Enums.StatusCodes.Status401Unauthorized,
                Msg = Enums.StatusCodes.Status401Unauthorized.ToDescription(),
                Success = false
            }
        ));
    }

    protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
    {
        Response.ContentType = "application/json";
        Response.StatusCode = StatusCodes.Status403Forbidden;
        await Response.WriteAsync(JsonHelper.Serialize(
            new ResponseStatusData
            {
                Code = Enums.StatusCodes.Status403Forbidden,
                Msg = Enums.StatusCodes.Status403Forbidden.ToDescription(),
                Success = false
            }
        ));
    }
}

public class ResponseStatusData
{
    public Enums.StatusCodes Code { get; set; } = Enums.StatusCodes.Status1Ok;
    public string Msg { get; set; }
    public bool Success { get; set; }

}
