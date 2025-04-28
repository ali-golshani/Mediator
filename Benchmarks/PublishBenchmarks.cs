using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class PublishBenchmarks : BenchmarksBase
{
    private readonly Mediator.Pinged mNotification = new();
    private readonly Minimal.Mediator.Pinged miNotification = new();
    private readonly MediatR.Pinged mrNotification = new();

    private readonly Mediator.PingedTwo mNotificationTwo = new();
    private readonly Minimal.Mediator.PingedTwo miNotificationTwo = new();
    private readonly MediatR.PingedTwo mrNotificationTwo = new();

    [Benchmark(Description = "Publish Mediator               ")]
    public async Task Mediator_Publish()
    {
        await mMediator.Publish(mNotification, default);
    }

    [Benchmark(Description = "Publish MinimalM               ")]
    public Task Minimal_Publish()
    {
        return miMediator.Publish(miNotification, default);
    }

    [Benchmark(Description = "Publish MediatR                ")]
    public Task MediatR_Publish()
    {
        return mrMediator.Publish(mrNotification);
    }

    [Benchmark(Description = "Publish Mediator - Two Handlers")]
    public async Task Mediator_Publish_TwoHandlers()
    {
        await mMediator.Publish(mNotificationTwo, default);
    }

    [Benchmark(Description = "Publish MinimalM - Two Handlers")]
    public Task Minimal_Publish_TwoHandlers()
    {
        return miMediator.Publish(miNotificationTwo, default);
    }

    [Benchmark(Description = "Publish MediatR  - Two Handlers")]
    public Task MediatR_Publish_TwoHandlers()
    {
        return mrMediator.Publish(mrNotificationTwo);
    }
}
