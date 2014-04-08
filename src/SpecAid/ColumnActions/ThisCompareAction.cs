using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Translations;

namespace SpecAid.ColumnActions
{
    //Action for storing items in the dictionary
    public class ThisCompareAction : ColumnAction, IComparerColumnAction
    {
        // Convert a Object to a Property
        private class ThisObject
        {
            public ThisObject(object obj)
            {
                This = obj;
            }

            public object This { get; set; }
        }

        public ThisCompareAction(Type targetType, string columnName)
            : base(targetType, columnName)
        {
        }

        private PropertyInfo Info { get; set; }

        public CompareColumnResult GoGoCompareColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var thisObject = new ThisObject(target);

            var compareResult = new CompareColumnResult();
            var expectedValue = Translator.Translate(Info, tableValue);
            var actualValue = thisObject == null ? null : Info.GetValue(thisObject, null);

            compareResult.ExpectedPrint = ToStringHelper.SafeToString(expectedValue);
            compareResult.ActualPrint = ToStringHelper.SafeToString(actualValue);

            // Refactor to be blah = blah 
            try
            {
                Assert.AreEqual(TypeConversion.SafeConvert(expectedValue, actualValue), actualValue);
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
            var thisObject = new ThisObject(target);

            // While the record is missing... this column isn't an error as it is n/a
            var compareResult = new CompareColumnResult();
            var actualValue = thisObject == null ? null : Info.GetValue(thisObject, null);
            compareResult.ActualPrint = ToStringHelper.SafeToString(actualValue);
            compareResult.IsError = false;
            return compareResult;
        }

        public override bool UseWhen()
        {
            if (!"This".Equals(ColumnName, StringComparison.InvariantCultureIgnoreCase))
                return false;

            Info = typeof (ThisObject).GetProperty("This");

            return true;
        }

        public override int considerOrder
        {
            get { return 3; }
        }
    }
}
