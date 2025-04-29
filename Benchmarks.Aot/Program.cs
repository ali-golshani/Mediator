namespace Benchmarks;

internal static class Program
{
    public static readonly bool DebugMode = true;

    static async Task Main()
    {
        if (DebugMode)
        {
            await DebugApp.Send();
            Console.WriteLine();
            await DebugApp.Publish();
            Console.ReadLine();
            return;
        }

        BenchmarkApp.Run();

        Console.WriteLine();
        Console.Write("Press Enter to Exit .");
        Console.ReadLine();
    }
}
