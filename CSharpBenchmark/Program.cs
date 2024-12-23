using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Security.Cryptography;

namespace CSharpBenchmark
{
    public class MyBenchmarks
    {
        private const int N = 10000;
        private readonly byte[] data;

        private readonly SHA256 sha256 = SHA256.Create();
        private readonly MD5 md5 = MD5.Create();

        public MyBenchmarks()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Run benchmarking on all types in the specified assembly
            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

            // Run benchmarking on the specified type
            var summary = BenchmarkRunner.Run<CompareLinq>();

            // Run benchmark on the specified type
            //var summary = BenchmarkRunner.Run(typeof(MyBenchmarks));
        }
    }
}
