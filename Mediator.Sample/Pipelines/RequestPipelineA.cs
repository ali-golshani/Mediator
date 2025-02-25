using Mediator.Middlewares;
using Mediator.Sample.Middlewares;
using Mediator.Sample.Requests;

namespace Mediator.Sample.Pipelines;

internal sealed class RequestPipelineA<TRequest, TResponse>
    : Pipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>, IRequestA
{
    public RequestPipelineA(
        IRequestHandler<TRequest, TResponse> handler,
        ExceptionHandlingMiddleware<TRequest, TResponse> exceptionHandling,
        ValidationMiddleware<TRequest, TResponse> validation)
        : base(handler, exceptionHandling, validation)
    { }
}