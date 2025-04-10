using Mediator.Middlewares;
using Mediator.Sample.Middlewares;

namespace Mediator.Sample.Pipelines;

internal sealed class RequestPipelineBConfiguration : IKeyedPipelineConfiguration
{
    public static string PipelineName { get; } = "Pipeline_B";

    public static Type[] Middlewares()
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
