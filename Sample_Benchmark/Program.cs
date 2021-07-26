using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Sample_Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateParser.UsingSplit("2021-07-26"));
            //Console.WriteLine(DateParser.UsingRegex("2021-07-26"));
            //Console.WriteLine(DateParser.UsingCompiledRegex("2021-07-26"));
            //Console.WriteLine(DateParser.UsingSubstring("2021-07-26"));
            //Console.WriteLine(DateParser.UsingSpan("2021-07-26"));
            //Console.WriteLine(DateParser.UsingDateTimeParse("2021-07-26"));
            //Console.WriteLine(DateParser.UsingDateTimeParseExact("2021-07-26"));
            //Console.ReadKey();

            BenchmarkRunner.Run<DateTimeParserBenchmark>();
        }
    }

    [MemoryDiagnoser]
    public class DateTimeParserBenchmark
    {
        private static string textToParse = "2021-07-26";

        [Benchmark] public DateTime UsingSplit() => DateParser.UsingSplit(textToParse);
        [Benchmark] public DateTime UsingRegex() => DateParser.UsingRegex(textToParse);
        [Benchmark] public DateTime UsingCompiledRegex() => DateParser.UsingCompiledRegex(textToParse);
        [Benchmark] public DateTime UsingSubstring() => DateParser.UsingSubstring(textToParse);
        [Benchmark] public DateTime UsingSpan() => DateParser.UsingSpan(textToParse);
        [Benchmark] public DateTime UsingDateTimeParse() => DateParser.UsingDateTimeParse(textToParse);
        [Benchmark] public DateTime UsingDateTimeParseExact() => DateParser.UsingDateTimeParse(textToParse);
    }

}
