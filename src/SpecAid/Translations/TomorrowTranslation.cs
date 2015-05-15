using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class TomorrowTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            return DateTime.Today.AddDays(1);  
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            
            return tableValue.Equals("[tomorrow]", StringComparison.InvariantCultureIgnoreCase);
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.Tomorrow.ToInt32(); }
        }
    }
}
