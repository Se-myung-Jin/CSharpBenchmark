using BenchmarkDotNet.Running;

namespace CSharpBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run benchmarking on all types in the specified assembly
            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

            // Run benchmarking on the specified type
            var summary = BenchmarkRunner.Run<CompareToStringBuilder>();

            // Run benchmark on the specified type
            //var summary = BenchmarkRunner.Run(typeof(MyBenchmarks));
        }
    }
}
