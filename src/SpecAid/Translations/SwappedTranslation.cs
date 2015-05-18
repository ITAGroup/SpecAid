using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;
using SpecAid.Helper;

namespace SpecAid.Translations
{
    public class SwappedTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            var tableValueSwapped = StringSwapper.Swap(tableValue);

            if (tableValueSwapped != tableValue)
            {
                // new text = new translation
                var item = Translator.Translate(info, tableValueSwapped);
                return item;
            }
            else
            {
                // if the swap doesn't do anything don't retranslate... 
                // but see if something else wants to do work.
                var item = Translator.TranslateContinueAfterOperation(info, tableValue, TranslationOrder.Swapped.ToInt32());
                return item;
            }
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return tableValue.Contains("{") && tableValue.Contains("}");
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.Swapped.ToInt32(); }
        }
    }
}
