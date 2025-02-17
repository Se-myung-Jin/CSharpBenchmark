using BenchmarkDotNet.Attributes;

namespace CSharpBenchmark
{
    [MemoryDiagnoser]
    public class CompareToString
    {
        [Benchmark]
        public void Boxing()
        {
            for (var i = 0; i < 100; i++)
            {
                var s =($"Test: {0}", i);
            }
        }


        [Benchmark]
        public void CastToString()
        {
            for (var i = 0; i < 100; i++)
            {
                var s = string.Format("Test: {0}", i);
            }
        }
    }
}
