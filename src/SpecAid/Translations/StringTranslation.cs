using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class StringTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            return tableValue.Substring(1,tableValue.Length - 2);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return tableValue.StartsWith("\"") && tableValue.EndsWith("\"");
        }

        // I am the ultimate override
        public int considerOrder
        {
            get { return TranslationOrder.String.ToInt32(); }
        }
    }
}
