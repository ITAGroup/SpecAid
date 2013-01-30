using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecAid.Helper
{
    public static class TagHelper
    {
        public static bool IsTag(string s)
        {
            return s.StartsWith("<<") && s.EndsWith(">>") && s.Length >=5;
        }
    }
}
