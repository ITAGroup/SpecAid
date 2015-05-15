using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;
using SpecAid.Helper;

namespace SpecAid.Translations
{
    public class TagSwappedTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            var tableValueTagSwapped = TagToStringSwapper.Swap(tableValue);
            return tableValueTagSwapped;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return tableValue.Contains("{") && tableValue.Contains("}");
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.TagSwapped.ToInt32(); }
        }
    }
}
