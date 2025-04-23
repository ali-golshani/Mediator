using BenchmarkDotNet.Running;

namespace Benchmarks;

internal static class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<SendBenchmarks>();
        Console.ReadLine();
    }
}
