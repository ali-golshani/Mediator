using Microsoft.Extensions.DependencyInjection;

namespace Mediator;

public static class ServiceConfigurations
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
    }
}
