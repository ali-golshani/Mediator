using Minimal.Mediator.Middlewares;

namespace Minimal.Mediator.Sample.Middlewares;

public sealed class ExceptionHandlingMiddleware<TRequest, TResponse> : IMiddleware<TRequest, TResponse>
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        Console.WriteLine("Middleware :: ExceptionHandlingMiddleware");

        try
        {
            return await next.Handle(context);
        }
        catch (Exception exp)
        {
            Console.WriteLine("Request  = {0} ; {1}", context.Request, exp);
            throw;
        }
    }
}