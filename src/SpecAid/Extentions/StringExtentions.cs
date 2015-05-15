using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecAid.Extentions
{
    public static class StringExtentions
    {
        public static string TrimAlphaOmega(this string thisValue)
        {
            if (string.IsNullOrEmpty(thisValue))
                return thisValue;

            if (thisValue.Length < 2)
                return thisValue;

            return thisValue.Substring(1, thisValue.Length - 2);
        }

        public static bool FirstAndLastBracketsMatch(this string thisValue, char startBracket, char endBracket)
        {
            if (!thisValue.StartsWith(startBracket.ToString()))
                return false;

            if (!thisValue.EndsWith(endBracket.ToString()))
                return false;

            var bracketCount = 0;
            var firstLoop = true;

            foreach (var character in thisValue)
            {
                if (!firstLoop)
                {
                    if (bracketCount == 0)
                        return false;
                }
                else
                    firstLoop = false;

                if (character == startBracket)
                {
                    bracketCount++;
                    continue;
                }

                if (character == endBracket)
                {
                    bracketCount--;
                    continue;
                }
            }

            if (bracketCount != 0)
                return false;

            return true;
        }
    }
}
