namespace ServiceName.Extensions;

internal static class HttpContextExtension
{
    public static Guid CreateCorrelationId(this HttpContext context)
    {
        var correlationId = Guid.NewGuid();
        context.Request.Headers.Append(CommonConstants.CorrelationId, $"{correlationId}");

        return correlationId;
    }

    public static Guid GetCorrelationId(this HttpContext context)
    {
        return context.Request.Headers.TryGetValue(CommonConstants.CorrelationId, out var correlationIdSource)
               && Guid.TryParse(correlationIdSource, out var correlationId)
            ? correlationId
            : Guid.Empty;
    }
}
