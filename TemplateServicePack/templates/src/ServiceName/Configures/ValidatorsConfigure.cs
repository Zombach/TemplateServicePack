using FluentValidation;
using ServiceName.Models.Hello;

namespace ServiceName.Configures;

internal static class ValidatorsConfigure
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<HelloRequest>, HelloRequestValidator>();

        return services;
    }
}
