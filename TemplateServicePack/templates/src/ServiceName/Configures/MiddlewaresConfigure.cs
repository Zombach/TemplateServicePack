using ServiceName.Middlewares;

namespace ServiceName.Configures;

internal static class MiddlewaresConfigure
{
    public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<CorrelationMiddleware>();
        app.UseMiddleware<ProfilingMiddleware>();

        return app;
    }
}
