
namespace eHubApi.Middleware;

public static class RequestLoggingExtensions
{
    public static IApplicationBuilder UseMyRequestLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<MyRequestLogger>();
        return app;
    }
}

internal class MyRequestLogger : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        return next(context);
    }
}