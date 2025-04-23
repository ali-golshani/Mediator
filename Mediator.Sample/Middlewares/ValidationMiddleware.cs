using FluentValidation;
using FluentValidation.Results;
using Minimal.Mediator.Middlewares;

namespace Minimal.Mediator.Sample.Middlewares;

public sealed class ValidationMiddleware<TRequest, TResponse> : IMiddleware<TRequest, TResponse>
{
    private readonly IValidator<TRequest>[] validators;

    public ValidationMiddleware(IEnumerable<IValidator<TRequest>>? validators)
    {
        this.validators = validators?.ToArray() ?? [];
    }

    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        Console.WriteLine("Middleware :: ValidationMiddleware");

        var validationResult = await ValidateAsync(validators, context.Request);
        var errors = validationResult.Errors;

        if (errors.Count > 0)
        {
            throw new ValidationException(errors);
        }

        return await next.Handle(context);
    }

    public static async Task<ValidationResult> ValidateAsync<T>(IValidator<T>[] validators, T value)
    {
        var results = new List<ValidationResult>();

        foreach (var validator in validators)
        {
            results.Add(await validator.ValidateAsync(value));
        }

        return new ValidationResult(results);
    }
}