using FluentValidation;

namespace Mediator.Sample.Requests.RegisterNumberCommand;

internal sealed class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        Console.WriteLine($"Register Number Validator");
        RuleFor(x => x.Number).GreaterThan(0);
    }
}
