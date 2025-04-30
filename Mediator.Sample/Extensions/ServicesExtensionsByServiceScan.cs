using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator;
using ServiceScan.SourceGenerator;

namespace ServiceScan;

public static partial class ServicesExtensionsByServiceScan
{
    [GenerateServiceRegistrations(AssignableTo = typeof(FluentValidation.IValidator<>), Lifetime = ServiceLifetime.Scoped)]
    public static partial IServiceCollection AddValidators(this IServiceCollection services);

    [GenerateServiceRegistrations(AssignableTo = typeof(IRequestHandler<,>), Lifetime = ServiceLifetime.Scoped)]
    public static partial IServiceCollection AddRequestHandlers(this IServiceCollection services);

    [GenerateServiceRegistrations(AssignableTo = typeof(INotificationHandler<>), Lifetime = ServiceLifetime.Scoped)]
    public static partial IServiceCollection AddNotificationHandlers(this IServiceCollection services);
}
