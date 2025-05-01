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

    [Benchmark(Description = "One Handlers - Minimal Publisher")]
    public Task Minimal_Publisher()
    {
        return miPublisher.Publish(miNotification, default);
    }

    [Benchmark(Description = "One Handlers - MediatR")]
    public Task MediatR_Publish()
    {
        return mrMediator.Publish(mrNotification);
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

    [Benchmark(Description = "Two Handlers - Minimal Publisher")]
    public Task Minimal_Publisher_TwoHandlers()
    {
        return miPublisherTwo.Publish(miNotificationTwo, default);
    }

    [Benchmark(Description = "Two Handlers - MediatR")]
    public Task MediatR_Publish_TwoHandlers()
    {
        return mrMediator.Publish(mrNotificationTwo);
    }
}
