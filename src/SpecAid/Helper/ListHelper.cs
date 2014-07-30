using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecAid.Helper
{
    public static class ListHelper
    {
        public static string NoBrackets(string theString)
        {
            if (theString.StartsWith("["))
                return theString.Substring(1, theString.Length - 2);

            return theString;
        }
    }
}
