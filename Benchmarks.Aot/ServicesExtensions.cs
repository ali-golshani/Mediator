using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator;
using ServiceScan.SourceGenerator;

namespace Benchmarks;

public static partial class ServicesExtensions
{
    [GenerateServiceRegistrations(AssignableTo = typeof(IRequestHandler<,>), Lifetime = ServiceLifetime.Scoped)]
    public static partial IServiceCollection AddRequestHandlers(this IServiceCollection services);

    [GenerateServiceRegistrations(AssignableTo = typeof(INotificationHandler<>), Lifetime = ServiceLifetime.Scoped)]
    public static partial IServiceCollection AddNotificationHandlers(this IServiceCollection services);
}
