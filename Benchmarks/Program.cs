using BenchmarkDotNet.Running;

namespace Benchmarks;

internal static class Program
{
    static void Main()
    {
        Console.WriteLine("Select Benchmark:");
        Console.WriteLine("1. Send Benchmark");
        Console.WriteLine("2. Publish Benchmark");
        Console.Write("Select: ");

        var key = Console.ReadKey();
        Console.WriteLine();

        if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
        {
            BenchmarkRunner.Run<SendBenchmarks>();
        }
        if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
        {
            BenchmarkRunner.Run<PublishBenchmarks>();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Invalid Input");
        }

        Console.WriteLine();
        Console.Write("Press Enter to Exit .");
        Console.ReadLine();
    }
}
