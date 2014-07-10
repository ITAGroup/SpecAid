using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    // Used for symbolic links
    public class TagTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            if (!RecallAid.It.ContainsKey(tableValue))
            {
                throw new Exception("Could not find tag: " + tableValue);
            }

            return RecallAid.It[tableValue];  
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return TagHelper.IsTag(tableValue);
        }

        // After String
        public int considerOrder
        {
            get { return TranslationOrder.Tag.ToInt32(); }
        }
    }
}
