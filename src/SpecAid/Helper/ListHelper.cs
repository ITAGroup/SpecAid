using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecAid.Extentions;

namespace SpecAid.Helper
{
    public static class ListHelper
    {
        public static string NoBrackets(string theString)
        {
            if (theString.StartsWith("["))
                return theString.TrimAlphaOmega();

            return theString;
        }
    }
}
