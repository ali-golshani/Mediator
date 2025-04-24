using BenchmarkDotNet.Running;

namespace Benchmarks;

internal static class Program
{
    static void Main()
    {
        Benchmark();
        Exit();
    }

    private static void Benchmark()
    {
        Console.WriteLine("Select Benchmark:");
        Console.WriteLine("1. Send");
        Console.WriteLine("2. Publish");
        Console.WriteLine();
        Console.Write("Select (1|2): ");

        var key = Console.ReadKey();
        Console.WriteLine();

        if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
        {
            BenchmarkRunner.Run<SendBenchmarks>();
        }
        else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
        {
            BenchmarkRunner.Run<PublishBenchmarks>();
        }
    }

    private static void Exit()
    {
        Console.WriteLine();
        Console.Write("Press Enter to Exit .");
        Console.ReadLine();
    }
}
