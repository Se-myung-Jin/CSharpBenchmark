using BenchmarkDotNet.Attributes;
using System.Text;

namespace CSharpBenchmark
{
    [MemoryDiagnoser]
    public class CompareToStringBuilder
    {
        [Benchmark(Baseline = true)]
        public void StringForLoop()
        {
            string ret = string.Empty;
            for (var i = 0; i < 100000000; i++)
            {
                ret += i.ToString();
            }
            Console.WriteLine(ret);
        }


        [Benchmark]
        public void StringBuilderForLoop()
        {
            var str = new StringBuilder();
            for (var i = 0; i < 100000000; i++)
            {
                str.Append(i.ToString());
            }

            Console.WriteLine(str);
        }
    }
}
