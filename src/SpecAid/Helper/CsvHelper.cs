using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecAid.Helper
{
    public static class CsvHelper
    {
        public static string ToCsv(string something)
        {
            if (something == null)
                return string.Empty;

            if (something.Contains("\""))
            {
                return ToQuotedCsv(something);
            }
            if (something.Contains(","))
            {
                return "\"" + something + "\"";
            }
            return something;
        }

        public static string ToQuotedCsv(string something)
        {
            if (something == null)
                return @"""""";

            var somethingFixed = something.Replace("\"", "\"\"");
            return "\"" + somethingFixed + "\"";
        }

        public static List<string> Split(string text)
        {
            var result = new List<string>();

            var readMe = new StringEnumWithPeek(text);

            var info = new CsvSplitInfo();
            info.FieldExpected = false;

            while (readMe.MoveNext())
            {
                // null not possible with inside a MoveNext loop
                var item = readMe.Current.Value;

                if (item == ' ')
                    continue;

                if (item == ',')
                {
                    result.Add(string.Empty);
                    info.FieldExpected = true;
                    continue;
                }

                if (item == '"')
                {
                    var quotedItem = ComsumeQuoted(info,readMe);
                    result.Add(quotedItem);
                    GoToNextItem(info, readMe);
                    continue;
                }

                var unquotedItem = ConsumeNoQuoted(info, item, readMe);
                result.Add(unquotedItem);
            }

            // ending comma situation
            if (info.FieldExpected)
                result.Add(string.Empty);

            return result;
        }

        private static string ConsumeNoQuoted(CsvSplitInfo info, char starter, StringEnumWithPeek readMe)
        {
            info.FieldExpected = false;

            var sb = new StringBuilder();
            sb.Append(starter);

            while (readMe.MoveNext())
            {
                // null not possible with inside a MoveNext loop
                var item = readMe.Current.Value;
                if (item == ',')
                {
                    info.FieldExpected = true;

                    // Remove ending spaces on No Quoted Fields
                    return sb.ToString().Trim();
                }

                sb.Append(item);
            }

            // Remove ending spaces on No Quoted Fields
            return sb.ToString().Trim();
        }

        private static string ComsumeQuoted(CsvSplitInfo info, StringEnumWithPeek readMe)
        {
            info.FieldExpected = false;

            var sb = new StringBuilder();
            sb.Append('"');

            while (readMe.MoveNext())
            {
                // null not possible with inside a MoveNext loop
                var item = readMe.Current.Value;
                if (item == '"')
                {
                    var nextItem = readMe.PeekNext();
                    if (nextItem == '"')
                    {
                        sb.Append('"');
                        readMe.MoveNext();
                        continue;
                    }
                    sb.Append('"');

                    return sb.ToString();
                }

                sb.Append(item);
            }

            sb.Append('"');

            return sb.ToString();
        }

        private static void GoToNextItem(CsvSplitInfo info, StringEnumWithPeek readMe)
        {
            while (readMe.MoveNext())
            {
                // null not possible with inside a MoveNext loop
                var item = readMe.Current.Value;
                if (item == ',')
                {
                    info.FieldExpected = true;
                    return;
                }
            }
        }
    }

    public class CsvSplitInfo
    {
        public bool FieldExpected { get; set; }
    }
}
