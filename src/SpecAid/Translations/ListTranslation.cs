using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SpecAid.Helper;
using SpecAid.Base;

namespace SpecAid.Translations
{
    public class ListTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            var tableValueNoBrackets = NoBrackets(tableValue);

            var tableValueEntries = CsvHelper.Split(tableValueNoBrackets);

            Type genericType = info.PropertyType.GetGenericArguments()[0];

            // Custom List to Return
            Type customList = typeof(List<>).MakeGenericType(genericType);
            IList objectList = (IList)Activator.CreateInstance(customList);

            // For a fake Property
            Type customInstanceType = typeof(ObjectField<>).MakeGenericType(genericType);
            var instance = Activator.CreateInstance(customInstanceType);
            var propertyInfo = instance.GetType().GetProperty("field");

            foreach (var tableValueEntry in tableValueEntries)
            {
                var expectedValue = Translator.Translate(propertyInfo, tableValueEntry);

                objectList.Add(expectedValue);
            }

            return objectList;
        }

        private string NoBrackets(string theString)
        {
            if (theString.StartsWith("["))
                return theString.Substring(1, theString.Length - 2);

            return theString;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            // Brackets are now Optional

            //if (!tableValue.StartsWith("["))
            //    return false;
            //
            //if (!tableValue.EndsWith("]"))
            //    return false;

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

        public int considerOrder
        {
            get { return 2; }
        }
    }
}
