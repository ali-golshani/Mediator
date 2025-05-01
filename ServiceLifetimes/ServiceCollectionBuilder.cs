using Microsoft.Extensions.DependencyInjection;

namespace ServiceLifetimes;

internal static class ServiceCollectionBuilder
{
    public static IServiceCollection Build()
    {
        var services = new ServiceCollection();
        RegisterServices(services);
        return services;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton(Console.Out);
        MediatR.Registry.AddMediatR(services);
        Mediator.Registry.AddMediator(services);
        Minimal.Mediator.Registry.AddMinimalMediator(services);
    }
}
