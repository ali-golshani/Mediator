using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator.Exceptions;
using Minimal.Mediator.Extensions;
using Minimal.Mediator.Middlewares;

namespace Minimal.Mediator;

internal sealed class Sender<TRequest, TResponse>(IServiceProvider serviceProvider) : ISender<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>
{
    private readonly IPipeline<TRequest, TResponse> pipeline = Pipeline(serviceProvider);

    public Task<TResponse> Send(TRequest request, CancellationToken cancellationToken)
    {
        return pipeline.Handle(request.AsRequestType(), cancellationToken);
    }

    private static IPipeline<TRequest, TResponse> Pipeline(IServiceProvider serviceProvider)
    {
        var pipelines = serviceProvider.GetServices<IPipeline<TRequest, TResponse>>().ToArray();

        if (pipelines.Length == 0)
        {
            var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
            return new EmptyPipeline<TRequest, TResponse>(handler);
        }

        if (pipelines.Length > 1)
        {
            var pipelineTypes = pipelines.Select(x => x.GetType()).ToArray();
            throw new DuplicateRequestPipelineException<TRequest>(pipelineTypes);
        }

        return pipelines[0];
    }
}