using System.Globalization;

namespace ServiceName.Configures;

internal static class ConfigurationsConfigure
{
    public static ConfigurationManager AddConfigurations
    (
        this ConfigurationManager configuration,
        string environment
    )
    {
        var directory = Path.GetDirectoryName(typeof(Program).Assembly.Location) ?? string.Empty;
        var basePath = Path.Combine(directory, "Configs");
        configuration.SetBasePath(basePath);

        configuration.AddAppSettings();
        configuration.AddAppSettings(environment);

        return configuration;
    }

    private static IConfigurationBuilder AddAppSettings(this IConfigurationBuilder configuration, string environment = "", bool reloadOnChange = true)
    {
        var appSettingsPath = environment.ToLower(CultureInfo.CurrentCulture) switch
        {
            "development" => "appsettings.development.json",
            "docker" => "appsettings.docker.json",
            _ => "appsettings.json",
        };

        return configuration.AddJsonFile
        (
            appSettingsPath,
            optional: true,
            reloadOnChange: reloadOnChange
        );
    }
}
