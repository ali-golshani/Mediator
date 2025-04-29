using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class PublishBenchmarks : BenchmarksBase
{
    private readonly Mediator.Pinged mNotification = new();
    private readonly Minimal.Mediator.Pinged miNotification = new();

    private readonly Mediator.PingedTwo mNotificationTwo = new();
    private readonly Minimal.Mediator.PingedTwo miNotificationTwo = new();

    [Benchmark(Description = "One Handlers - Mediator (Source-Generator)")]
    public async Task Mediator_Publish()
    {
        await mMediator.Publish(mNotification, default);
    }

    [Benchmark(Description = "One Handlers - Minimal Mediator")]
    public Task Minimal_Publish()
    {
        return miMediator.Publish(miNotification, default);
    }

    [Benchmark(Description = "Two Handlers - Mediator (Source-Generator)")]
    public async Task Mediator_Publish_TwoHandlers()
    {
        await mMediator.Publish(mNotificationTwo, default);
    }

    [Benchmark(Description = "Two Handlers - Minimal Mediator")]
    public Task Minimal_Publish_TwoHandlers()
    {
        return miMediator.Publish(miNotificationTwo, default);
    }
}
