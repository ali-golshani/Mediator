using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Benchmarks;

public static class ServiceCollectionBuilder
{
    public static IServiceCollection Build()
    {
        var services = new ServiceCollection();
        global::Mediator.ServiceConfigurations.AddMediator(services);
        ServiceConfigurations.RegisterServices(services);
        return services;
    }
}
