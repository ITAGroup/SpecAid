using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.SetTranslations;
using SpecAid.Translations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    public class IndexerCompareAction : ColumnAction, IComparerColumnAction
    {
        private PropertyInfo _info;
        private object _lookUp;

        public IndexerCompareAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        public CompareColumnResult GoGoCompareColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var compareResult = new CompareColumnResult();

            var expectedValue = Translator.Translate(_info, tableValue);
            expectedValue = SetTranslator.Translate(_info, target, expectedValue);

            var actualValue = GetActual(target);

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
                compareResult.ErrorMessage = "Error on Indexer, Expected '" + compareResult.ExpectedPrint + "', Actual '" + compareResult.ActualPrint + "'";
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
            // While the record is missing... this column isn't an error as it is n/a
            var compareResult = new CompareColumnResult();
            var actualValue = GetActual(target);
            compareResult.ActualPrint = ToStringHelper.SafeToString(actualValue);
            compareResult.IsError = false;
            return compareResult;
        }

        public override bool UseWhen()
        {
            _info = PropertyInfoHelper.GetIndexerPropertyInfo(TargetType, ColumnName);

            if (_info == null)
                return false;

            var parameterType = _info.GetIndexParameters().First().ParameterType;
            _lookUp = Convert.ChangeType(ColumnName, parameterType);

            return true;
        }

        public override int considerOrder
        {
            get { return ActionOrder.IndexerCompare.ToInt32(); }
        }

        private object GetActual(object target)
        {
            if (target == null)
                return null;

            try
            {
                var item = _info.GetValue(target, new object[] { _lookUp });
                return item;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.GetType() == typeof (KeyNotFoundException))
                {
                    Console.WriteLine(
                        "Key {0} for Indexer on {1} not found.",
                        ColumnName,
                        target.GetType());
                    return null;
                }

                if (ex.InnerException != null)
                {
                    Console.WriteLine(
                        "Key {0} for Indexer on {1} blew stuff up: {2}",
                        ColumnName,
                        target.GetType(),
                        ex.Message);
                    return null;
                }

                // not certain how we get here with reflection.
                throw;
            }
        }
    }
}
