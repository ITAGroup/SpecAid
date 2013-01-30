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
            var tableValueNoBrackets = tableValue.Substring(1, tableValue.Length - 2);
            var tableValueEntries = tableValueNoBrackets.Split(',').ToList();

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

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            // Tags are in the form <<TagName>>
            // Tags can also have Deep-Linked properties using the Tag as a starting point
            // eg.  <<Dealer001>>.SalesDistrict.Code

            
            if (!tableValue.StartsWith("["))
                return false;

            if (!tableValue.EndsWith("]"))
                return false;

            if ((typeof(IList).IsAssignableFrom(info.PropertyType)) ||
                typeof(IList<>).IsAssignableFrom(info.PropertyType) ||
                (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                return true;
            }

            return false;
        }

        public int considerOrder
        {
            get { return 2; }
        }
    }
}
