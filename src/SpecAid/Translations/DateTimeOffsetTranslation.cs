using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class DateTimeOffsetTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            return DateTimeOffset.Parse(tableValue);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return info.PropertyType == typeof(DateTimeOffset);
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.DateTimeOffset.ToInt32(); }
        }
    }
}
