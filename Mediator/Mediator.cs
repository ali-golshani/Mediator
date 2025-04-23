using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator.Exceptions;
using Minimal.Mediator.Extensions;
using Minimal.Mediator.Middlewares;

namespace Minimal.Mediator;

internal sealed class Mediator(IServiceProvider serviceProvider) : IMediator
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public Task<TResponse> Send<TRequest, TResponse>(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken)
        where TRequest : IRequest<TRequest, TResponse>
    {
        var pipelines = serviceProvider.GetServices<IPipeline<TRequest, TResponse>>().ToList();

        if (pipelines.Count == 0)
        {
            throw new MissingRequestPipelineException<TRequest>();
        }

        if (pipelines.Count > 1)
        {
            var pipelineTypes = pipelines.Select(x => x.GetType()).ToArray();
            throw new DuplicateRequestPipelineException<TRequest>(pipelineTypes);
        }

        var pipeline = pipelines[0];
        return pipeline.Handle(request.AsRequestType(), cancellationToken);
    }

    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken)
        where TNotification : INotification
    {
        return
            serviceProvider
            .GetRequiredService<Publisher<TNotification>>()
            .Publish(notification, cancellationToken);
    }
}