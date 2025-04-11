﻿namespace Mediator.Sample.Requests;

public sealed class SpecialRequestB : IRequest<SpecialRequestB, string>, IRequestB, ISpecialRequest
{ }

public sealed class SpecialRequestBHandler : IRequestHandler<SpecialRequestB, string>
{
    public Task<string> Handle(SpecialRequestB request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Special Request B");
    }
}
