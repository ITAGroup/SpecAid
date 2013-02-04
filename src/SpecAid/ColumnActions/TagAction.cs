using System;
using SpecAid.Base;

namespace SpecAid.ColumnActions
{
    //Action for storing items in the dictionary
    public class SetLinkAction : ColumnAction, ICreatorColumnAction
    {
        public SetLinkAction(Type targetType, string columnName)
            : base(targetType, columnName)
        {
        }

        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

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
            get { return 3; }
        }

    }
}
