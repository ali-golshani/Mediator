namespace Minimal.Mediator.Middlewares;

public interface IRequestProcessor<TRequest, TResponse>
{
    Task<TResponse> Handle(RequestContext<TRequest> context);
}
