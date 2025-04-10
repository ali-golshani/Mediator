using Microsoft.Extensions.DependencyInjection;

namespace Mediator;

public static class ServiceConfigurations
{
    public static void AddMediator(IServiceCollection services)
    {
        services.AddTransient(typeof(Publisher<>));
        services.AddScoped<IMediator, Mediator>();
    }
}
