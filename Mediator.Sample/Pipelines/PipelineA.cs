using Minimal.Mediator.Middlewares;
using Minimal.Mediator.Sample.Middlewares;
using Minimal.Mediator.Sample.Requests;

namespace Minimal.Mediator.Sample.Pipelines;

internal static class PipelineA
{
    internal sealed class Pipeline<TRequest, TResponse> : KeyedPipeline<TRequest, TResponse>
        where TRequest : IRequest<TRequest, TResponse>, IRequestA
    {
        public Pipeline(IServiceProvider serviceProvider)
            : base(serviceProvider, Configuration.PipelineName)
        { }
    }

    internal sealed class Configuration : IKeyedPipelineConfiguration
    {
        public static string PipelineName { get; } = "Pipeline_A";

        public static MiddlewareDescriptor[] Middlewares()
        {
            return
            [
                new MiddlewareDescriptor(typeof(ExceptionHandlingMiddleware<,>)),
                new MiddlewareDescriptor(typeof(MiddlewareA<,>)),
                new MiddlewareDescriptor(typeof(PingMiddleware), typeof(IMiddleware<Ping, Pong>)),
            ];
        }
    }
}
