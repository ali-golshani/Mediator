using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks;

public class BenchmarksBase
{
    protected Mediator.IMediator mMediator = null!;
    protected Minimal.Mediator.IMediator miMediator = null!;
    private protected Minimal.Mediator.ISender<Minimal.Mediator.Ping, int> miSender = null!;
    private protected Minimal.Mediator.IPublisher<Minimal.Mediator.Pinged> miPublisher = null!;
    private protected Minimal.Mediator.IPublisher<Minimal.Mediator.PingedTwo> miPublisherTwo = null!;
    protected MediatR.IMediator mrMediator = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var services = ServiceCollectionBuilder.Build();
        var rootServiceProvider = services.BuildServiceProvider();

        mMediator = rootServiceProvider.GetRequiredService<Mediator.IMediator>();
        miMediator = rootServiceProvider.GetRequiredService<Minimal.Mediator.IMediator>();
        miSender = rootServiceProvider.GetRequiredService<Minimal.Mediator.ISender<Minimal.Mediator.Ping, int>>();
        miPublisher = rootServiceProvider.GetRequiredService<Minimal.Mediator.IPublisher<Minimal.Mediator.Pinged>>();
        miPublisherTwo = rootServiceProvider.GetRequiredService<Minimal.Mediator.IPublisher<Minimal.Mediator.PingedTwo>>();
        mrMediator = rootServiceProvider.GetRequiredService<MediatR.IMediator>();
    }
}
