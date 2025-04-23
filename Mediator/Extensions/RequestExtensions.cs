using Minimal.Mediator.Exceptions;

namespace Minimal.Mediator.Extensions;

public static class RequestExtensions
{
    public static TRequest AsRequestType<TRequest, TResponse>(this IRequest<TRequest, TResponse> request)
    {
        if (request is not TRequest result)
        {
            throw new UnexpectedRequestTypeException<TRequest>(request);
        }

        return result;
    }
}
