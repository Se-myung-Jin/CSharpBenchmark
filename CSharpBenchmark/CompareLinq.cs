using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBenchmark
{
    [MemoryDiagnoser]
    public class CompareLinq
    {
        public int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [Benchmark(Baseline = true)]
        public void LinqMethod()
        {
            var list = arr.Where(x => x > 4).Select(x => x);
        }

        [Benchmark]
        public void LinqMethod2()
        {
            var list = arr.Select(x => x).Where(x => x > 4);
        }


        [Benchmark]
        public void LinqToSql()
        {
            var list = from n in arr
                       where n > 4
                       select n;
        }
    }
}
