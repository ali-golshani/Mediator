using Mediator.Middlewares;

namespace Mediator.Benchmarks.Pipelines;

internal sealed class PipelineConfiguration : IKeyedPipelineConfiguration
{
    public static string PipelineName { get; } = "Pipeline";

    public static Type[] Middlewares()
    {
        return
        [
            typeof(Middlewares.GenericRequestPreProcessor<,>),
            typeof(Middlewares.GenericPipelineBehavior<,>),
            typeof(Middlewares.GenericRequestPostProcessor<,>),
        ];
    }
}
