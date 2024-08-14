using Serilog;
using Serilog.Extensions.Hosting;
using Serilog.Settings.Configuration;

namespace ServiceName.Configures;

internal static class LoggersConfigure
{
    public static WebApplicationBuilder AddLoggers(this WebApplicationBuilder builder, params string[] sectionNames)
    {
        builder.Logging.ClearProviders();

        foreach (var sectionNam in sectionNames)
        {
            var logger = builder.AddSerilog(sectionNam);
            builder.Logging.AddSerilog(logger);
        }

        return builder;
    }

    private static ReloadableLogger AddSerilog(this WebApplicationBuilder builder, string sectionName)
    {
        return new LoggerConfiguration()
            .ReadFrom.Configuration(
                builder.Configuration,
                new ConfigurationReaderOptions { SectionName = sectionName })
            .Enrich.FromLogContext()
            .CreateBootstrapLogger();
    }
}
