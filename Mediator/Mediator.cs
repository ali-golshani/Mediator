using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator.Extensions;

namespace Minimal.Mediator;

internal sealed class Mediator(IServiceProvider serviceProvider) : IMediator
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public Task<TResponse> Send<TRequest, TResponse>(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TRequest, TResponse>
    {
        return
            serviceProvider
            .GetRequiredService<ISender<TRequest, TResponse>>()
            .Send(request.AsRequestType(), cancellationToken);
    }

    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        where TNotification : INotification
    {
        return
            serviceProvider
            .GetRequiredService<IPublisher<TNotification>>()
            .Publish(notification, cancellationToken);
    }
}