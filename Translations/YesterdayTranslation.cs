using System;
using System.Reflection;
using SpecAid.Base;

namespace SpecAid.Translations
{
    public class YesterdayTranslation : ITranslation
    {

        public object Do(PropertyInfo info, string tableValue)
        {
            return DateTime.Today.AddDays(-1);  
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return tableValue.Equals("[yesterday]", StringComparison.InvariantCultureIgnoreCase);
        }

        public int considerOrder
        {
            get { return 1; }
        }
    }
}
