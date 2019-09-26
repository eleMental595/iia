using iia.middlewares;
using Microsoft.AspNetCore.Builder;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder RegisterMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandler>();
        return app;
    }
}