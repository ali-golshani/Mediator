using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator;
using Minimal.Mediator.Middlewares;

namespace ServiceLifetimes;

public static class PingPipeline
{
    public sealed class Pipeline<TRequest, TResponse> : KeyedPipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>
    {
        public Pipeline(IServiceProvider serviceProvider)
            : base(serviceProvider, Configuration.PipelineName)
        { }
    }

    public sealed class Configuration : IKeyedPipelineConfiguration
    {
        public static string PipelineName { get; } = "PingPipeline";

        public static MiddlewareDescriptor[] Middlewares()
        {
            return
            [
                new MiddlewareDescriptor(typeof(PingMiddleware), typeof(IMiddleware<Ping, Pong>), ServiceLifetime.Transient),
            ];
        }
    }
}