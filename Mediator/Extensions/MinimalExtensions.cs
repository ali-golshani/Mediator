using Minimal.Mediator;
using Minimal.Mediator.Middlewares;

namespace Microsoft.Extensions.DependencyInjection;

public static class MinimalExtensions
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddTransient(typeof(Publisher<>));
        services.AddScoped<IMediator, Mediator>();
    }

    public static void AddMiddlewares<TPipelineConfiguration>(this IServiceCollection services)
        where TPipelineConfiguration : IKeyedPipelineConfiguration
    {
        foreach (var type in TPipelineConfiguration.Middlewares())
        {
            services.AddKeyedScoped(typeof(IMiddleware<,>), TPipelineConfiguration.PipelineName, type);
        }
    }
}
