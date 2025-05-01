using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class SendBenchmarks : BenchmarksBase
{
    private readonly Mediator.Ping mRequest = new() { Message = "Hello World" };
    private readonly Minimal.Mediator.Ping miRequest = new() { Message = "Hello World" };
    private readonly MediatR.Ping mrRequest = new() { Message = "Hello World" };

    [Benchmark(Description = "Mediator (Source-Generator)")]
    public async Task Mediator_Send()
    {
        await mMediator.Send(mRequest, default);
    }

    [Benchmark(Description = "Minimal Mediator")]
    public Task Minimal_Send()
    {
        return miMediator.Send(miRequest, default);
    }

    [Benchmark(Description = "Minimal Sender")]
    public Task Minimal_Sender()
    {
        return miSender.Send(miRequest, default);
    }

    [Benchmark(Description = "MediatR")]
    public Task MediatR_Send()
    {
        return mrMediator.Send(mrRequest);
    }
}
