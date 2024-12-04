using okala_task.Services;

namespace okala_task.DependencyInjection;

public static class AddRepositoriesInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, ConfigurationManager configuration)
    {

        services.AddScoped<ICurrencyService, CurrencyService>();

        return services;
    }
}

