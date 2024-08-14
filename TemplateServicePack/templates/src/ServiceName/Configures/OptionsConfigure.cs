using ServiceName.Options;

namespace ServiceName.Configures;

internal static class OptionsConfigure
{
    public static IServiceCollection AddOptions
    (
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddOptionsWithValidate<InstanceOptions>(configuration.GetSection(InstanceOptions.SectionKey));

        return services;
    }

    private static void AddOptionsWithValidate<T>(
        this IServiceCollection services,
        IConfigurationSection configurationSection)
        where T : BaseOptions
    {
        services.AddOptionsWithValidateOnStart<T>()
            .Bind(configurationSection)
            .ValidateDataAnnotations();
    }
}
