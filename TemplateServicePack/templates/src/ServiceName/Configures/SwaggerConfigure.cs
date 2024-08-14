using System.Text.Json.Serialization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace ServiceName.Configures;

internal static class SwaggerConfigure
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;

        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.MapType<TimeSpan>(() => new OpenApiSchema
            {
                Type = "string",
                Example = new OpenApiString("00:00:00")
            });
            options.EnableAnnotations();
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "ServiceName", Version = "v1" });
            options.UseInlineDefinitionsForEnums();
        });
        services.AddRouting(options => options.LowercaseUrls = true);

        return services;
    }

    public static IApplicationBuilder SwaggerSetup(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}
