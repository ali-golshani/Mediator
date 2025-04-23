using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private Mediator.IMediator mMediator = null!;
    private readonly Mediator.Ping mRequest = new() { Message = "Hello World" };
    private readonly Mediator.Pinged mNotification = new();

    private Minimal.Mediator.IMediator miMediator = null!;
    private readonly Minimal.Mediator.Ping miRequest = new() { Message = "Hello World" };
    private readonly Minimal.Mediator.Pinged miNotification = new();

    private MediatR.IMediator mrMediator = null!;
    private readonly MediatR.Ping mrRequest = new() { Message = "Hello World" };
    private readonly MediatR.Pinged mrNotification = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
        var services = ServiceCollectionBuilder.Build();
        var rootServiceProvider = services.BuildServiceProvider();

        mMediator = rootServiceProvider.GetRequiredService<Mediator.IMediator>();
        miMediator = rootServiceProvider.GetRequiredService<Minimal.Mediator.IMediator>();
        mrMediator = rootServiceProvider.GetRequiredService<MediatR.IMediator>();
    }

    [Benchmark]
    public async Task Mediator_Send()
    {
        await mMediator.Send(mRequest, default);
    }

    [Benchmark]
    public async Task Mediator_Publish()
    {
        await mMediator.Publish(mNotification, default);
    }

    [Benchmark]
    public Task Minimal_Send()
    {
        return miMediator.Send(miRequest, default);
    }

    [Benchmark]
    public Task Minimal_Publish()
    {
        return miMediator.Publish(miNotification, default);
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
