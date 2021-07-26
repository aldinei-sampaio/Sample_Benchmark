using System;
using System.Text.RegularExpressions;

namespace Sample_Benchmark
{
    public class DateParser
    {
        public static DateTime UsingSplit(string value)
        {
            var splitted = value.Split("-");
            return new DateTime(
                int.Parse(splitted[0]),
                int.Parse(splitted[1]),
                int.Parse(splitted[2])
            );
        }

        public static DateTime UsingRegex(string value)
        {
            var match = Regex.Match(value, @"^(\d\d\d\d)-(\d\d)-(\d\d)$");
            return new DateTime(
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value)
            );
        }

        private static readonly Regex regex = new Regex(@"^(\d\d\d\d)-(\d\d)-(\d\d)$", RegexOptions.Compiled);
        public static DateTime UsingCompiledRegex(string value)
        {
            var match = regex.Match(value);
            return new DateTime(
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value)
            );
        }

        public static DateTime UsingSubstring(string value)
        {
            return new DateTime(
                int.Parse(value.Substring(0, 4)),
                int.Parse(value.Substring(5, 2)),
                int.Parse(value.Substring(8, 2))
            );
        }

        public static DateTime UsingSpan(string value)
        {
            return new DateTime(
                int.Parse(value.AsSpan(0, 4)),
                int.Parse(value.AsSpan(5, 2)),
                int.Parse(value.AsSpan(8, 2))
            );
        }

        public static DateTime UsingDateTimeParse(string value)
        {
            return DateTime.Parse(value);
        }

        public static DateTime UsingDateTimeParseExact(string value)
        {
            return DateTime.ParseExact(value, "yyyy-MM-dd", null);
        }

    }
}
