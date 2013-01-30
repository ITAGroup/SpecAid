using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Translations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecAid.ColumnActions
{
    public class CompareAction : ColumnAction, IComparerColumnAction
    {

        public CompareAction(Type targetType, string columnName)
            : base(targetType, columnName)
        {
        }

        private PropertyInfo Info { get; set; }

        public CompareColumnResult GoGoCompareColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var compareResult = new CompareColumnResult();

            var expectedValue = Translator.Translate(Info, tableValue);
            var actualValue = target == null ? null : Info.GetValue(target, null);

            compareResult.ExpectedPrint = ToStringHelper.SafeToString(expectedValue);
            compareResult.ActualPrint = ToStringHelper.SafeToString(actualValue);

            // Refactor to be blah = blah 
            try
            {
                Assert.AreEqual(TypeConversion.SafeConvert(expectedValue,actualValue), actualValue);
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

            // While the record is missing... this column isn't an error as it is n/a
            var compareResult = new CompareColumnResult();
            var expectedValue = Translator.Translate(Info, tableValue);

            compareResult.ExpectedPrint = ToStringHelper.SafeToString(expectedValue);
            compareResult.IsError = false;
            return compareResult;
        }

        public CompareColumnResult GoGoCompareColumnAction(object target)
        {
            // While the record is missing... this column isn't an error as it is n/a
            var compareResult = new CompareColumnResult();
            var actualValue = target == null ? null : Info.GetValue(target, null);
            compareResult.ActualPrint = ToStringHelper.SafeToString(actualValue);
            compareResult.IsError = false;
            return compareResult;
        }

        public override bool UseWhen()
        {
            Info = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(TargetType, ColumnName);

            //could not find the property on the object
            return (Info != null);
        }

        public override int considerOrder
        {
            get { return 5; }
        }

    }
}
