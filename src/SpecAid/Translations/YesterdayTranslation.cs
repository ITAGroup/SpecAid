using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;

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

        public int ConsiderOrder
        {
            get { return TranslationOrder.Yesterday.ToInt32(); }
        }
    }
}
