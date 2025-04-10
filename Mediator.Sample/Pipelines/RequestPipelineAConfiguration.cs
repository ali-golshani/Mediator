using Mediator.Middlewares;
using Mediator.Sample.Middlewares;

namespace Mediator.Sample.Pipelines;

internal sealed class RequestPipelineAConfiguration : IKeyedPipelineConfiguration
{
    public static string PipelineName { get; } = "Pipeline_A";

    public static Type[] Middlewares()
    {
        return
        [
            typeof(ExceptionHandlingMiddleware<,>),
            typeof(MiddlewareA<,>),
        ];
    }
}
