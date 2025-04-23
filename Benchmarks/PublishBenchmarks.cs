using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class PublishBenchmarks : BenchmarksBase
{
    private readonly Mediator.Pinged mNotification = new();
    private readonly Minimal.Mediator.Pinged miNotification = new();
    private readonly MediatR.Pinged mrNotification = new();

    [Benchmark]
    public async Task Mediator_Publish()
    {
        await mMediator.Publish(mNotification, default);
    }

    [Benchmark]
    public Task Minimal_Publish()
    {
        return miMediator.Publish(miNotification, default);
    }

    [Benchmark]
    public Task MediatR_Publish()
    {
        return mrMediator.Publish(mrNotification);
    }
}
