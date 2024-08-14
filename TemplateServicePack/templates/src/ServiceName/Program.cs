using Microsoft.Extensions.Options;
using ServiceName.Configures;
using ServiceName.Options;

ILogger<Program>? logger = default;
try
{
    var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;

    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "development";
    configuration.AddConfigurations(environment);

    builder.AddLoggers("LogDefault");

    builder.Services.AddSwagger();
    builder.Services.AddOptions(configuration);
    builder.Services.AddServices();
    builder.Services.AddValidators();

    var app = builder.Build();
    app.AddMiddlewares();
    app.SwaggerSetup();

    using var scope = app.Services.CreateScope();

    var instanceOptions = scope.ServiceProvider.GetRequiredService<IOptions<InstanceOptions>>();
    logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogInformation(
        "PodId: {@prodId}, environment: {@environment}",
        instanceOptions.Value.ProdId,
        environment);

    app.Run();
}
catch (Exception ex)
{

    logger?.LogCritical(ex, "Message: {@message}", ex.Message);
}
finally
{
    logger?.LogInformation("Shutdown complete");
}
