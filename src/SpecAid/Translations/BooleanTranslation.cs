using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class BooleanTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            return bool.Parse(tableValue);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return info.PropertyType == typeof(bool);
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.Boolean.ToInt32(); }
        }
    }
}
