using BenchmarkDotNet.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CSharpBenchmark
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public static class ListExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AsSpan<T>(this List<T> list)
        {
            return CollectionsMarshal.AsSpan(list);
        }
    }

    [MemoryDiagnoser]
    [RPlotExporter]
    public class CompareSpan
    {
        public List<Person> list = new List<Person>(100);

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Person { Id = i, Name = "Kim" + i });
            }
        }

        [Benchmark(Baseline = true)]
        public void Common()
        {
            foreach (var person in list)
            {
                person.Id++;
            }
        }


        [Benchmark]
        public void AsSpan()
        {
            foreach (var person in list.AsSpan())
            {
                person.Id++;
            }
        }
    }
}
