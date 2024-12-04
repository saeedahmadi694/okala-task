using okala_task.Configs;

namespace okala_task.DependencyInjection;

public static class AddConfigurations
{
    public static IServiceCollection AddAppConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ExchangeratesConfig>(options => configuration.GetSection(ExchangeratesConfig.Key).Bind(options));
        return services;
    }
}