using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks;

public class BenchmarksBase
{
    protected Mediator.IMediator mMediator = null!;
    protected Minimal.Mediator.IMediator miMediator = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var services = ServiceCollectionBuilder.Build();
        var rootServiceProvider = services.BuildServiceProvider();

        mMediator = rootServiceProvider.GetRequiredService<Mediator.IMediator>();
        miMediator = rootServiceProvider.GetRequiredService<Minimal.Mediator.IMediator>();
    }
}
