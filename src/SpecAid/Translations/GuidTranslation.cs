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
            if (info.PropertyType == typeof (Guid))
                return true;
            if (info.PropertyType == typeof(Guid?))
                return true;
            return false;
        }

        public int considerOrder
        {
            get { return 7; }
        }
    }
}
