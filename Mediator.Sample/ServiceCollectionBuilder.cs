using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Sample;

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
