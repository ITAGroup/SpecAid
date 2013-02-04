using System;
using System.Reflection;
using SpecAid.Base;

namespace SpecAid.Translations
{
    //Used for symbollic links
    public class NullTranslation : ITranslation  
    {

        public object Do(PropertyInfo info, string tableValue)
        {
            return null;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return tableValue.Equals("null", StringComparison.InvariantCultureIgnoreCase);
        }
        public int considerOrder
        {
            get { return 1; }
        }
    }
}
