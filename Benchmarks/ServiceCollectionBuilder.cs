using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks;

public static class ServiceCollectionBuilder
{
    public static IServiceCollection Build()
    {
        var services = new ServiceCollection();
        Mediator.ServiceConfigurations.AddMediator(services);
        ServiceConfigurations.RegisterServices(services);
        return services;
    }
}
