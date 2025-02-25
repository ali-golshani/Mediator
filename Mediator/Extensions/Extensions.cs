using Mediator.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Extensions;

public static class Extensions
{
    public static Task<TResponse> SendToHandler<TRequest, TResponse>(
        this IServiceProvider serviceProvider,
        IRequest<TRequest, TResponse> request,
        CancellationToken cancellationToken)
        where TRequest : IRequest<TRequest, TResponse>
    {
        var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
        return handler.Handle(request.AsRequestType(), cancellationToken);
    }

    public static TRequest AsRequestType<TRequest, TResponse>(this IRequest<TRequest, TResponse> request)
    {
        if (request is not TRequest result)
        {
            throw new UnexpectedRequestTypeException<TRequest>(request);
        }

        return result;
    }
}
