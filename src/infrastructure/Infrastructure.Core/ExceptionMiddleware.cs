﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core;

/// <summary>
/// 异常中间件
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (AppException ex)
        {
            await HandleAppExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleAppExceptionAsync(HttpContext context, AppException appException)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.OK;

        return context.Response.WriteAsync(JsonHelper.Serialize(new ResultOutput<string>()
        {
            Code = appException.AppCode
        }.NotOk(appException.AppMessage)));
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var authorization = context.Request.Headers.Authorization.FirstOrDefault();
        var userAgent = context.Request.Headers.UserAgent.FirstOrDefault();
        context.Items.TryGetValue("_ActionArguments", out object? actionArguments);
        _logger.LogError(exception,
        "Error while processing request. ActionArguments: {ActionArguments}, Authorization: {Authorization}, UserAgent: {UserAgent}",
        actionArguments != null ? JsonHelper.Serialize(actionArguments) : "",
        authorization,
        userAgent);

        return context.Response.WriteAsync(JsonHelper.Serialize(new ResultOutput<string>().NotOk(exception.Message)));
    }
}