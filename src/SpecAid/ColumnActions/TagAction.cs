using System;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    //Action for storing items in the dictionary
    public class SetLinkAction : ColumnAction, ICreatorColumnAction, IComparerColumnAction
    {
        public SetLinkAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        public CompareColumnResult GoGoCompareColumnAction(object obj, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var compareResults = new CompareColumnResult();
            compareResults.ActualPrint = tableValue;
            compareResults.ExpectedPrint = tableValue;

            TagIt(obj, tableValue);

            return compareResults;
        }

        public CompareColumnResult GoGoCompareColumnAction(object obj)
        {
            var compareResults = new CompareColumnResult();
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


        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

            TagIt(target, tableValue);
        }

        private void TagIt(object target, string tableValue)
        {
            if (string.IsNullOrWhiteSpace(tableValue))
                return;

            RecallAid.It[tableValue] = target;
        }

        public override bool UseWhen()
        {
            return "Tag It".Equals(ColumnName, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int considerOrder
        {
            get { return ActionOrder.Tag.ToInt32(); }
        }
    }
}
