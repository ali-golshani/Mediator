namespace Minimal.Mediator.Middlewares;

public interface IMiddleware<TRequest, TResponse>
{
    Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next);
}
