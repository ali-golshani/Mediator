namespace Benchmarks;

internal static class DebugApp
{
    public static async Task Publish()
    {
        var benchmarks = new PublishBenchmarks();
        benchmarks.GlobalSetup();
        await benchmarks.MediatR_Publish();
        await benchmarks.Minimal_Publish();
        await benchmarks.Mediator_Publish();
    }

    public static async Task Send()
    {
        var benchmarks = new SendBenchmarks();
        benchmarks.GlobalSetup();
        await benchmarks.MediatR_Send();
        await benchmarks.Minimal_Send();
        await benchmarks.Mediator_Send();
    }
}
