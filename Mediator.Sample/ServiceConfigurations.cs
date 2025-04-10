using Mediator.Extensions;
using Mediator.Middlewares;
using Mediator.Sample.Extensions;
using Mediator.Sample.Middlewares;
using Mediator.Sample.Pipelines;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Sample;

public static class ServiceConfigurations
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.RegisterRequestHandlers();
        services.RegisterValidators();
        services.RegisterPipelines();
    }

    private static void RegisterPipelines(this IServiceCollection services)
    {
        /// Required for RequestPipelineA registration
        services.AddTransient(typeof(ValidationMiddleware<,>));
        services.AddTransient(typeof(ExceptionHandlingMiddleware<,>));

        services.AddTransient(typeof(IPipeline<,>), typeof(RequestPipelineA<,>));

        services.AddTransient(typeof(IPipeline<,>), typeof(RequestPipelineB<,>));
        services.RegisterMiddlewares<RequestPipelineBConfiguration>();
    }
}
