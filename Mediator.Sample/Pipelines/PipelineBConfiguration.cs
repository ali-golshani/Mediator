using Minimal.Mediator.Middlewares;
using Minimal.Mediator.Sample.Middlewares;

namespace Minimal.Mediator.Sample.Pipelines;

internal sealed class PipelineBConfiguration : IKeyedPipelineConfiguration
{
    public static string PipelineName { get; } = "Pipeline_B";

    public static MiddlewareDescriptor[] Middlewares()
    {
        return
        [
            typeof(ExceptionHandlingMiddleware<,>),
            typeof(ValidationMiddleware<,>),
            typeof(SpecialMiddleware<,>),
            typeof(MiddlewareB<,>),
        ];
    }
}
