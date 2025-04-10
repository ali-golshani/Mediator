﻿using FluentValidation;

namespace Mediator.Sample.Requests.RequestB;

internal sealed class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        Console.WriteLine($"Request Number Validator");
        RuleFor(x => x.Number).GreaterThan(0);
    }
}
