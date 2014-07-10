using System;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    public class IgnoreAction : ColumnAction, IComparerColumnAction, ICreatorColumnAction
    {
        public IgnoreAction(Type targetType, string columnName) : base(targetType, columnName)
        {
            //intentionally do nothing
        }

        public CompareColumnResult GoGoCompareColumnAction(object obj, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var compareResults = new CompareColumnResult();
            compareResults.ActualPrint = tableValue;
            compareResults.ExpectedPrint = tableValue;
            // Convert any tags...

            return compareResults;
        }

        public CompareColumnResult GoGoCompareColumnAction(object obj)
        {
            var compareResults = new CompareColumnResult();
            // Convert any tags...
            return compareResults;
        }

        public CompareColumnResult GoGoCompareColumnAction(string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var compareResults = new CompareColumnResult();
            compareResults.ExpectedPrint = tableValue;

            return compareResults;
        }


        public void GoGoCreateColumnAction(object obj, string tableValue)
        {
            //intentionally do nothing
        }

        public override bool UseWhen()
        {
            return ColumnName.StartsWith("!");
        }

        public override int considerOrder
        {
            get { return ActionOrder.Ignore.ToInt32(); }
        }
    }
}
