namespace Minimal.Mediator.Middlewares;

public interface IPipeline<in TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
