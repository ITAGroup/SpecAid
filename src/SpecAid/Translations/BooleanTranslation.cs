using System;
using System.Reflection;
using SpecAid.Base;

namespace SpecAid.Translations
{
    public class BooleanTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            return Boolean.Parse(tableValue);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return info.PropertyType == typeof(Boolean);
        }

        public int considerOrder
        {
            get { return 1; }
        }
    }
}
