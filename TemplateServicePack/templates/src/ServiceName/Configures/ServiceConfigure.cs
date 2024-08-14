using ServiceName.Services;
using ServiceName.Services.Interfaces;

namespace ServiceName.Configures;

internal static class ServiceConfigure
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITestService, TestService>();

        return services;
    }
}
