using BenchmarkDotNet.Running;
using System;

namespace Benchmark_Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running benchmark-");
            var summary = BenchmarkRunner.Run<GetCommonSitesBenchmark>();
        }
    }
}
