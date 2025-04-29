using Microsoft.Extensions.DependencyInjection;
using ServiceScan.SourceGenerator;

namespace Minimal.Mediator.Sample;

public static partial class ServicesExtensions
{
    [GenerateServiceRegistrations(AssignableTo = typeof(IRequestHandler<,>), Lifetime = ServiceLifetime.Scoped)]
    public static partial IServiceCollection AddRequestHandlers(this IServiceCollection services);

    [GenerateServiceRegistrations(AssignableTo = typeof(FluentValidation.IValidator<>), Lifetime = ServiceLifetime.Scoped)]
    public static partial IServiceCollection AddValidators(this IServiceCollection services);
}
