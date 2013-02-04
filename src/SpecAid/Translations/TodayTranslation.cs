using System;
using System.Reflection;
using SpecAid.Base;

namespace SpecAid.Translations
{
    public class TodayTranslation : ITranslation
    {

        public object Do(PropertyInfo info, string tableValue)
        {
            return DateTime.Today;  
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return tableValue.Equals("[today]", StringComparison.InvariantCultureIgnoreCase);
        }


        public int considerOrder
        {
            get { return 1; }
        }

    }
}
