using BenchmarkDotNet.Running;

namespace Benchmarks;

internal static class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<Benchmarks>();
        Console.ReadLine();
    }
}
