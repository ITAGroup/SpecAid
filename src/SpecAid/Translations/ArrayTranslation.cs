using System;
using System.Reflection;
using SpecAid.Helper;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class ArrayTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            var tableValueNoBrackets = ListHelper.NoBrackets(tableValue);
            var tableValueEntries = CsvHelper.Split(tableValueNoBrackets);
            
            var numEntries = tableValueEntries.Count;
            var baseType = info.PropertyType.GetElementType();

            var array = Array.CreateInstance(baseType, numEntries);

            var propertyInfo = InstantProperty.FromType(baseType);

            for (int i = 0; i < numEntries; i++)
            {
                var expectedValue = Translator.Translate(propertyInfo, tableValueEntries[i]);
                array.SetValue(expectedValue,i);
            }

            return array;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            if (info.PropertyType.IsArray)
                return true;

            return false;
        }

        public int considerOrder
        {
            get { return TranslationOrder.List.ToInt32(); }
        }
    }
}
