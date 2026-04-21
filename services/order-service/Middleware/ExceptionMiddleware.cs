using System.Net;
using System.Text.Json;

namespace OrderService.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpResponse response = context.Response;
        response.ContentType = "application/json";

        response.StatusCode = ex switch
        {
            ArgumentException => (int)HttpStatusCode.BadRequest,
            InvalidOperationException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };
        string result = JsonSerializer.Serialize(new
        {
            message = ex.Message
        });

        return response.WriteAsync(result);
    }
}
