using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class DateTimeTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            return DateTime.Parse(tableValue);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return info.PropertyType == typeof(DateTime);
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.DateTime.ToInt32(); }
        }
    }
}
