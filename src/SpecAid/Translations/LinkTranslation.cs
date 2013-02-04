using System;
using System.Reflection;
using SpecAid.Base;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using SpecAid.Helper;

namespace SpecAid.Translations
{
    //Used for symbollic links
    public class LinkTranslation : ITranslation
    {

        public object Do(PropertyInfo info, string tableValue)
        {
            if (!RecallAid.It.ContainsKey(tableValue))
            {
                throw new Exception("Could not find tag/link: " + tableValue);
            }

            return RecallAid.It[tableValue];  
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return TagHelper.IsTag(tableValue);
        }

        public int considerOrder
        {
            get { return 1; }
        }
    }
}
