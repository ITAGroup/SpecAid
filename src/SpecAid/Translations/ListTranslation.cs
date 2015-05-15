using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using SpecAid.Helper;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class ListTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            var tableValueNoBrackets = ListHelper.NoBrackets(tableValue);

            var tableValueEntries = CsvHelper.Split(tableValueNoBrackets);

            // This will allow PlainLists to work.
            Type innerType = typeof(object);

            if (info.PropertyType.IsGenericType)
                innerType = info.PropertyType.GetGenericArguments()[0];

            // Custom List to Return
            Type customList = typeof(List<>).MakeGenericType(innerType);
            IList objectList = (IList)Activator.CreateInstance(customList);

            var propertyInfo = InstantProperty.FromType(innerType);

            foreach (var tableValueEntry in tableValueEntries)
            {
                var expectedValue = Translator.Translate(propertyInfo, tableValueEntry);

                objectList.Add(expectedValue);
            }

            return objectList;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            // UseWhen does not test for Brackets because Brackets are optional

            // Strings are Enumerable... But Compare Action is the one to use.
            if (typeof(string).IsAssignableFrom(info.PropertyType))
                return false;

            if (typeof (IList).IsAssignableFrom(info.PropertyType))
                return true;

            if (typeof (IList<>).IsAssignableFrom(info.PropertyType))
                return true;

            if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
                return true;

            if (typeof(IEnumerable).IsAssignableFrom(info.PropertyType))
                return true;

            if (typeof(IEnumerable<>).IsAssignableFrom(info.PropertyType))
                return true;

            return false;
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.List.ToInt32(); }
        }
    }
}
