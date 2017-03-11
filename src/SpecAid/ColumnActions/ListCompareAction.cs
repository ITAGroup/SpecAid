using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using SpecAid.Translations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    public class ListCompareAction : ColumnAction, IComparerColumnAction
    {
        private PropertyInfo _info;

        public ListCompareAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        public CompareColumnResult GoGoCompareColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var compareResult = new CompareColumnResult();

            var expectedValue = (IList)Translator.Translate(_info, tableValue);
            var actualValue = GetActual(target);

            compareResult.ExpectedPrint = SafeListToString(expectedValue);
            compareResult.ActualPrint = SafeListToString(actualValue);

            // Refactor to be blah = blah
            try
            {
                CollectionAssert.AreEquivalent(expectedValue, actualValue);
            }
            catch (Exception)
            {
                compareResult.IsError = true;
                compareResult.ErrorMessage = "Error on Property " + _info.Name + ", Expected '" + compareResult.ExpectedPrint + "', Actual '" + compareResult.ActualPrint + "'";
            }

            return compareResult;
        }

        private IList GetActual(object target)
        {
            if (target == null)
                return null;

            if (typeof(IList).IsAssignableFrom(_info.PropertyType))
                return (IList)(_info.GetValue(target, null));

            if (IsGenericList(_info.PropertyType))
                return (IList)(_info.GetValue(target, null));

            // Need to convert the Enumerable Information into a List for Collection Assert.
            if (typeof(IEnumerable).IsAssignableFrom(_info.PropertyType))
            {
                var orginalEnumerable = (IEnumerable)(_info.GetValue(target, null));

                if (orginalEnumerable == null)
                    return null;

                var actualValue = new ArrayList();
                foreach (var item in orginalEnumerable)
                {
                    actualValue.Add(item);
                }
                return actualValue;
            }

            // This shouldn't happen
            return null;
        }

        public CompareColumnResult GoGoCompareColumnAction(string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var compareResult = new CompareColumnResult();
            var expectedValue = (IList)Translator.Translate(_info, tableValue);

            compareResult.ExpectedPrint = SafeListToString(expectedValue);
            compareResult.IsError = false;
            return compareResult;
        }

        public CompareColumnResult GoGoCompareColumnAction(object target)
        {
            // While the record is missing... this column isn't an error as it is n/a
            var compareResult = new CompareColumnResult();
            var actualValue = (IList)(target == null ? null : _info.GetValue(target, null));
            compareResult.ActualPrint = SafeListToString(actualValue);
            compareResult.IsError = false;
            return compareResult;
        }

        public string SafeListToString(IList items)
        {
            if (items == null)
                return "null";

            var sb = new StringBuilder();
            sb.Append("[");

            var isFirst = true;

            foreach (var item in items)
            {
                if (isFirst)
                    isFirst = false;
                else
                    sb.Append(",");

                var outputString = ToStringHelper.SafeToString(item);
                var csvSafeString = CsvHelper.ToCsv(outputString);

                sb.Append(csvSafeString);
            }

            sb.Append("]");
            return sb.ToString();
        }

        public override bool UseWhen()
        {
            _info = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(TargetType, ColumnName);

            if (_info == null)
                return false;

            if (typeof(string).IsAssignableFrom(_info.PropertyType))
                return false;

            if (typeof (IList).IsAssignableFrom(_info.PropertyType))
                return true;

            if (IsGenericList(_info.PropertyType))
                return true;

            if (typeof(IEnumerable).IsAssignableFrom(_info.PropertyType))
                return true;

            return false;
        }

        //http://stackoverflow.com/questions/1177434/isnt-a-generic-ilist-assignable-from-a-generic-list
        public static bool IsGenericList(Type type)
        {
            if (!type.IsGenericType)
                return false;

            var genericArguments = type.GetGenericArguments();
            if (genericArguments.Length != 1)
                return false;

            var listType = typeof(IList<>).MakeGenericType(genericArguments);
            return listType.IsAssignableFrom(type);
        }

        public override int considerOrder
        {
            get { return ActionOrder.ListCompare.ToInt32(); }
        }
    }
}
