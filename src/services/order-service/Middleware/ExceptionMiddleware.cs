using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpResponse response = context.Response;
        response.ContentType = "application/json";

        int statusCode = ex switch
        {
            ArgumentException => (int)HttpStatusCode.BadRequest,
            InvalidOperationException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };

        response.StatusCode = statusCode;

        ProblemDetails problemDetails= new ProblemDetails
        {
            Status = statusCode,
            Title = ex.GetType().Name,
            Detail = ex.Message,
            Instance = context.Request.Path
        };

        string result = JsonSerializer.Serialize(problemDetails);

        return response.WriteAsync(result);
    }
}
