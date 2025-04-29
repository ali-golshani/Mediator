namespace Benchmarks;

internal static class DebugApp
{
    public static async Task Publish()
    {
        var benchmarks = new PublishBenchmarks();
        benchmarks.GlobalSetup();

        Console.WriteLine("Mediator Publish");
        await benchmarks.Mediator_Publish();

        Console.WriteLine();

        Console.WriteLine("Minimal Publish");
        await benchmarks.Minimal_Publish();
    }

    public static async Task Send()
    {
        var benchmarks = new SendBenchmarks();
        benchmarks.GlobalSetup();

        Console.WriteLine("Mediator Send");
        await benchmarks.Mediator_Send();

        Console.WriteLine();

        Console.WriteLine("Minimal Send");
        await benchmarks.Minimal_Send();
    }
}
