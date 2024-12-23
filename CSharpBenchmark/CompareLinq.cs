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

        [Benchmark]
        public void Count()
        {
            var list = arr.Select(x => x).Where(x => x > 4).ToList();
        }


        [Benchmark]
        public void Any()
        {
            var list = from n in arr
                       where n > 4
                       select n;
        }

        [Benchmark]
        public void Any2()
        {
            var list = from n in arr
                       where n > 4
                       select n;
        }
    }
}
