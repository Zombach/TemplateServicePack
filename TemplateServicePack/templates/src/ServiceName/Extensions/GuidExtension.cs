namespace ServiceName.Extensions;

internal static class GuidExtension
{
    public static bool IsEmpty(this Guid id)
    {
        return id == Guid.Empty;
    }
}
