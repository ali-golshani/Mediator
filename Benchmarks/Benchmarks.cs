using BenchmarkDotNet.Attributes;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private IMediator mediator = null!;
    private readonly Ping request = new() { Message = "Hello World" };
    private readonly Pinged notification = new();

    private MediatR.IMediator mrMediator = null!;
    private readonly MediatR.Ping mrRequest = new() { Message = "Hello World" };
    private readonly MediatR.Pinged mrNotification = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
        var services = ServiceCollectionBuilder.Build();
        var rootServiceProvider = services.BuildServiceProvider();

        mediator = rootServiceProvider.GetRequiredService<IMediator>();
        mrMediator = rootServiceProvider.GetRequiredService<MediatR.IMediator>();
    }

    [Benchmark]
    public Task Mediator_Send()
    {
        return mediator.Send(request, default);
    }

    [Benchmark]
    public Task Mediator_Publish()
    {
        return mediator.Publish(notification, default);
    }

    [Benchmark]
    public Task MediatR_Send()
    {
        return mrMediator.Send(mrRequest);
    }

    [Benchmark]
    public Task MediatR_Publish()
    {
        return mrMediator.Publish(mrNotification);
    }
}
