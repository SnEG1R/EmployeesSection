using System.Net;
using System.Net.Mime;
using System.Reflection;
using EmployeesSection.Application.Common.Attributes;
using Newtonsoft.Json;

namespace EmployeesSection.Web.Middleware;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
    private const string ContentType = "application/json";

    public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error - {E}", e);
            await HandleExceptionAsync(context, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var exceptionType = exception.GetType();
        var statusCodeExceptionAttribute = exceptionType.GetCustomAttribute<StatusCodeExceptionAttribute>();
        var statusCode = HttpStatusCode.InternalServerError;
        if (statusCodeExceptionAttribute != null)
            statusCode = statusCodeExceptionAttribute.StatusCode;

        context.Response.ContentType = ContentType;
        context.Response.StatusCode = (int)statusCode;
        
        var result = JsonConvert.SerializeObject(new { error = exception.Message });

        return context.Response.WriteAsync(result);
    }
}