using System;
using System.Reflection;
using SpecAid.Base;

namespace SpecAid.Translations
{
    public class GuidTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            return new Guid(tableValue);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return info.PropertyType == typeof(Guid);
        }

        public int considerOrder
        {
            get { return 7; }
        }
    }
}
