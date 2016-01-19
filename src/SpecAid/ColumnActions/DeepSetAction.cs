using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    // Action for setting the value in the object nested in other objects
    public class DeepSetAction : ColumnAction, ICreatorColumnAction
    {
        private ICreatorColumnAction _deepAction;

        public DeepSetAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        private PropertyInfo Info { get; set; }

        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

            if (_deepAction != null)
                _deepAction.GoGoCreateColumnAction(Info.GetValue(target, null), tableValue);
        }

        public override bool UseWhen()
        {
            if (!DeepHelper.IsDeep(ColumnName))
                return false;

            var columnNameParts = DeepHelper.SplitColumnName(ColumnName);

            Info = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(
                TargetType, columnNameParts.FirstColumn);

            //if (Info == null) it might be indexer

            _deepAction = ColumnActionFactory.GetAction<ICreatorColumnAction>(
                Info.PropertyType, columnNameParts.OtherColumns);

            if (_deepAction == null)
                return false;

            return _deepAction.UseWhen();
        }

        public override int considerOrder
        {
            get { return ActionOrder.DeepSet.ToInt32(); }
        }
    }
}
