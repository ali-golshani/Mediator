using BenchmarkDotNet.Attributes;
using Mediator.Benchmarks.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private IMediator mediator = null!;
    private readonly Ping request = new() { Message = "Hello World" };
    private readonly Pinged notification = new();

    private MediatR.IMediator mrMediator = null!;
    private readonly MediatR.Benchmarks.Ping mrRequest = new() { Message = "Hello World" };
    private readonly MediatR.Benchmarks.Pinged mrNotification = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
        var services = ServiceCollectionBuilder.Build();
        var rootServiceProvider = services.BuildServiceProvider();

        mediator = rootServiceProvider.GetRequiredService<IMediator>();
        mrMediator = rootServiceProvider.GetRequiredService<MediatR.IMediator>();
    }

    [Benchmark]
    public Task SendingRequests()
    {
        return mediator.Send(request, default);
    }

    [Benchmark]
    public Task PublishingNotifications()
    {
        return mediator.Publish(notification, default);
    }

    [Benchmark]
    public Task MR_SendingRequests()
    {
        return mrMediator.Send(mrRequest);
    }

    [Benchmark]
    public Task MR_PublishingNotifications()
    {
        return mrMediator.Publish(mrNotification);
    }
}
