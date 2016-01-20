using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Translations;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    //Action for storing items in the dictionary
    public class ThisCompareAction : ColumnAction, IComparerColumnAction
    {
        private PropertyInfo _info;

        public ThisCompareAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        public CompareColumnResult GoGoCompareColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var thisObject = new ThisObject(target);

            var compareResult = new CompareColumnResult();
            var expectedValue = Translator.Translate(_info, tableValue);
            var actualValue = thisObject == null ? null : _info.GetValue(thisObject, null);

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
                compareResult.ErrorMessage = "Error on Property " + _info.Name + ", Expected '" + compareResult.ExpectedPrint + "', Actual '" + compareResult.ActualPrint + "'";
            }

            return compareResult;
        }

        public CompareColumnResult GoGoCompareColumnAction(string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            // While the record is missing... this column isn't an error as it is n/a
            var compareResult = new CompareColumnResult();
            var expectedValue = Translator.Translate(_info, tableValue);

            compareResult.ExpectedPrint = ToStringHelper.SafeToString(expectedValue);
            compareResult.IsError = false;
            return compareResult;
        }

        public CompareColumnResult GoGoCompareColumnAction(object target)
        {
            var thisObject = new ThisObject(target);

            // While the record is missing... this column isn't an error as it is n/a
            var compareResult = new CompareColumnResult();
            var actualValue = thisObject == null ? null : _info.GetValue(thisObject, null);
            compareResult.ActualPrint = ToStringHelper.SafeToString(actualValue);
            compareResult.IsError = false;
            return compareResult;
        }

        public override bool UseWhen()
        {
            if (!"This".Equals(ColumnName, StringComparison.InvariantCultureIgnoreCase))
                return false;

            _info = typeof (ThisObject).GetProperty("This");

            return true;
        }

        public override int considerOrder
        {
            get { return ActionOrder.ThisCompare.ToInt32(); }
        }
    }
}
