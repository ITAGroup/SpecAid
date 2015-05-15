using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;
using SpecAid.Helper;

namespace SpecAid.Translations
{
    public class QuotedStringTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            // When using quotes we want the raw values.
            // no translation
            // no [datetime] alter.
            // no {#tag} alter.

            var trimmedString = tableValue.TrimAlphaOmega();

            return trimmedString;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return tableValue.StartsWith("\"") && tableValue.EndsWith("\"");
        }

        // I am the ultimate override
        public int ConsiderOrder
        {
            get { return TranslationOrder.QuotedString.ToInt32(); }
        }
    }
}
