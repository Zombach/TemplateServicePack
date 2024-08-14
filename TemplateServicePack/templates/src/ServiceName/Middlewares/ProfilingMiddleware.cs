using System.Diagnostics;

namespace ServiceName.Middlewares;

internal sealed class ProfilingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, ILogger<ProfilingMiddleware> logger)
    {
        var stopwatch = Stopwatch.StartNew();

        context.Response.OnStarting(state =>
        {
            stopwatch.Stop();

            var httpContext = (HttpContext)state;
            httpContext.Response.Headers.Append(
                CommonConstants.ProcessingTime,
                new[] { $"request executed in {stopwatch.ElapsedMilliseconds} milliseconds" });

            logger.LogInformation(
                "request executed in {@milliseconds} milliseconds",
                stopwatch.ElapsedMilliseconds);

            return Task.CompletedTask;
        }, context);

        await next(context);
    }
}
