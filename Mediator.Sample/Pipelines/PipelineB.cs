using Minimal.Mediator.Middlewares;
using Minimal.Mediator.Sample.Middlewares;
using Minimal.Mediator.Sample.Requests;

namespace Minimal.Mediator.Sample.Pipelines;

internal static class PipelineB
{
    internal sealed class Pipeline<TRequest, TResponse> : KeyedPipeline<TRequest, TResponse>
        where TRequest : IRequest<TRequest, TResponse>, IRequestB
    {
        public Pipeline(IServiceProvider serviceProvider)
            : base(serviceProvider, Configuration.PipelineName)
        { }
    }

    internal sealed class Configuration : IKeyedPipelineConfiguration
    {
        public static string PipelineName { get; } = "Pipeline_B";

        public static MiddlewareDescriptor[] Middlewares()
        {
            return
            [
                new MiddlewareDescriptor(typeof(ExceptionHandlingMiddleware<,>)),
                new MiddlewareDescriptor(typeof(ValidationMiddleware<,>)),
                new MiddlewareDescriptor(typeof(SpecialMiddleware<,>)),
                new MiddlewareDescriptor(typeof(MiddlewareB<,>)),
            ];
        }
    }
}
