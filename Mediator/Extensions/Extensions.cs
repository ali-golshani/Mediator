using Mediator.Exceptions;
using Mediator.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Extensions;

public static class Extensions
{
    public static void RegisterMiddlewares<TPipelineConfiguration>(this IServiceCollection services)
        where TPipelineConfiguration : IKeyedPipelineConfiguration
    {
        foreach (var type in TPipelineConfiguration.Middlewares())
        {
            services.AddKeyedScoped(typeof(IMiddleware<,>), TPipelineConfiguration.PipelineName, type);
        }
    }

    public static TRequest AsRequestType<TRequest, TResponse>(this IRequest<TRequest, TResponse> request)
    {
        if (request is not TRequest result)
        {
            throw new UnexpectedRequestTypeException<TRequest>(request);
        }

        return result;
    }
}
