using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;
using SpecAid.Helper;

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

        public int ConsiderOrder
        {
            get { return TranslationOrder.Guid.ToInt32(); }
        }
    }
}
