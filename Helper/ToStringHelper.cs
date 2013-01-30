using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecAid.Helper
{
    public static class ToStringHelper
    {
        public static string SafeToString(object item)
        {
            if (item == null)
                return "null";

            string fullName = item.GetType().FullName;
            string asString = item.ToString();

            // Avoid really gross output when ToString is not overriden
            if (fullName == asString)
                return item.GetType().Name;

            return asString;
        }
    }
}
