using Serilog.Context;
using ServiceName.Extensions;

namespace ServiceName.Middlewares;

public class CorrelationMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var correlationId = context.GetCorrelationId();
        if (correlationId.IsEmpty())
        {
            correlationId = context.CreateCorrelationId();
        }

        context.Response.OnStarting(state =>
        {
            var httpContext = (HttpContext)state;
            httpContext.Response.Headers.Append(CommonConstants.CorrelationId, new[] { $"{correlationId}" });

            return Task.CompletedTask;
        }, context);

        using (LogContext.PushProperty(CommonConstants.CorrelationId, correlationId))
        {
            await next.Invoke(context);
        }
    }
}
