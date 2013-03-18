using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;

namespace SpecAid
{
    public static class RowAid
    {
        public static string GetCell(TableRow row, string header)
        {
            if (row.ContainsKey(header))
                return row[header];

            var lookup = CleanAndShrink(header);

            foreach (var key in row.Keys)
            {
                if (CleanAndShrink(key) == lookup)
                    return row[key];
            }

            // This WILL trigger an exception, but it's the exception we need.
            return row[header];
        }

        private static string CleanAndShrink(string header)
        {
            return Regex.Replace(header, @"\s+", "").ToLower();
        }
    }
}
