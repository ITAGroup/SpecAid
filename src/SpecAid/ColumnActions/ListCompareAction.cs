using System;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using SpecAid.Translations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Base;
using SpecAid.Helper;

namespace SpecAid.Base.ColumnActions
{
    public class ListCompareAction : ColumnAction, IComparerColumnAction
    {
        private PropertyInfo Info { get; set; }

        public ListCompareAction(Type targetType, string columnName)
            : base(targetType, columnName)
        {
        }

        public CompareColumnResult GoGoCompareColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var compareResult = new CompareColumnResult();

            var expectedValue = (IList)Translator.Translate(Info, tableValue);
            var actualValue = (IList)(target == null ? null : Info.GetValue(target, null));

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
                compareResult.ErrorMessage = "Error on Property " + Info.Name + ", Expected '" + compareResult.ExpectedPrint + "', Actual '" + compareResult.ActualPrint + "'";
            }

            return compareResult;
        }

        public CompareColumnResult GoGoCompareColumnAction(string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var compareResult = new CompareColumnResult();
            var expectedValue = (IList)Translator.Translate(Info, tableValue);

            compareResult.ExpectedPrint = SafeListToString(expectedValue);
            compareResult.IsError = false;
            return compareResult;
        }

        public CompareColumnResult GoGoCompareColumnAction(object target)
        {
            // While the record is missing... this column isn't an error as it is n/a
            var compareResult = new CompareColumnResult();
            var actualValue = (IList)(target == null ? null : Info.GetValue(target, null));
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

            var IsFirst = true;

            foreach (var item in items)
            {
                if (IsFirst)
                    IsFirst = false;
                else
                    sb.Append(",");

                var outputString = ToStringHelper.SafeToString(item);

                sb.Append(outputString);
            }

            sb.Append("]");
            return sb.ToString();
        }

        public override bool UseWhen()
        {
            Info = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(TargetType, ColumnName);

            if (Info == null)
                return false;

            var assignable = (typeof (IList).IsAssignableFrom(Info.PropertyType));

            return assignable;
        }

        public override int considerOrder
        {
            get { return 4; }
        }
    }
}
