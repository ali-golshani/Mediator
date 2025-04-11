using BenchmarkDotNet.Running;

namespace Mediator.Benchmarks;

internal static class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<Benchmarks>();
        Console.ReadLine();
    }
}
