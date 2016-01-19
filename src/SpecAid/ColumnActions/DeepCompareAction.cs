using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    public class DeepCompareAction : ColumnAction, IComparerColumnAction
    {
        private PropertyInfo Info { get; set; }
        private IComparerColumnAction _deepAction;

        public DeepCompareAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        public CompareColumnResult GoGoCompareColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            if (_deepAction != null)
                return _deepAction.GoGoCompareColumnAction(Info.GetValue(target, null), tableValue);

            return new CompareColumnResult();
        }

        public CompareColumnResult GoGoCompareColumnAction(string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            if (_deepAction != null)
                return _deepAction.GoGoCompareColumnAction(tableValue);

            return new CompareColumnResult();
        }

        public CompareColumnResult GoGoCompareColumnAction(object target)
        {
            if (_deepAction != null)
                return _deepAction.GoGoCompareColumnAction(Info.GetValue(target, null));

            return new CompareColumnResult();
        }

        public override bool UseWhen()
        {
            if (!DeepHelper.IsDeep(ColumnName))
                return false;

            var columnNameParts = DeepHelper.SplitColumnName(ColumnName);

            Info = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(
                TargetType, columnNameParts.FirstColumn);

            //if (Info == null) it might be indexer

            _deepAction = ColumnActionFactory.GetAction<IComparerColumnAction>(
                Info.PropertyType, 
                columnNameParts.OtherColumns);

            if (_deepAction == null)
                return false;

            return _deepAction.UseWhen();
        }

        public override int considerOrder
        {
            get { return ActionOrder.DeepCompare.ToInt32(); }
        }
    }
}
