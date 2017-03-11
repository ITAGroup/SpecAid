using System;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    public class UnknownAction : ColumnAction, IComparerColumnAction, ICreatorColumnAction
    {
        public UnknownAction(Type targetType, string columnName)
            : base(targetType, columnName)
        {
            //intentionally do nothing
        }

        public CompareColumnResult GoGoCompareColumnAction(object obj, string tableValue)
        {
            return new CompareColumnResult();
        }

        public CompareColumnResult GoGoCompareColumnAction(object obj)
        {
            return new CompareColumnResult();
        }

        public CompareColumnResult GoGoCompareColumnAction(string tableValue)
        {
            return new CompareColumnResult();
        }

        public void GoGoCreateColumnAction(object obj, string tableValue)
        {
            //intentionally do nothing
        }

        public override bool UseWhen()
        {
            if (!SpecAidSettings.AssertWhenUnknownColumn)
            {
                Console.WriteLine("Unable to determine what to do with column:" + base.ColumnName);
                return true;
            }

            return false;
        }

        public override int considerOrder
        {
            get { return ActionOrder.Unknown.ToInt32(); }
        }
    }
}
