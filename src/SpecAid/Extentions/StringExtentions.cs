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
    }
}
