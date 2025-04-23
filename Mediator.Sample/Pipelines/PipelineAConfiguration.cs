using Minimal.Mediator.Middlewares;
using Minimal.Mediator.Sample.Middlewares;

namespace Minimal.Mediator.Sample.Pipelines;

internal sealed class PipelineAConfiguration : IKeyedPipelineConfiguration
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
