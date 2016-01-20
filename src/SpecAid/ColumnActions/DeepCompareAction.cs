using System;
using System.Linq;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    public class DeepCompareAction : ColumnAction, IComparerColumnAction
    {
        private IComparerColumnAction _deepAction;
        private PropertyInfo _info;
        private bool _isIndexer;
        private object _lookUp;

        public DeepCompareAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        public CompareColumnResult GoGoCompareColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return new CompareColumnResult();

            var value = GetActual(target);

            if (_deepAction != null)
                return _deepAction.GoGoCompareColumnAction(value, tableValue);

            return new CompareColumnResult();
        }

        private object GetActual(object target)
        {
            if (_isIndexer)
                return _info.GetValue(target, new[] { _lookUp });
            
            return _info.GetValue(target, null);
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
            var value = GetActual(target);

            if (_deepAction != null)
                return _deepAction.GoGoCompareColumnAction(value);

            return new CompareColumnResult();
        }

        public override bool UseWhen()
        {
            if (!DeepHelper.IsDeep(ColumnName))
                return false;

            var columnNameParts = DeepHelper.SplitColumnName(ColumnName);

            if (!UseWhenProperty(columnNameParts.FirstColumn))
                return false;

            _deepAction = ColumnActionFactory.GetAction<IComparerColumnAction>(
                _info.PropertyType, 
                columnNameParts.OtherColumns);

            if (_deepAction == null)
                return false;

            return _deepAction.UseWhen();
        }

        private bool UseWhenProperty(string firstColumnName)
        {
            _info = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(
                TargetType, firstColumnName);

            if (_info != null)
                return true;

            _info = PropertyInfoHelper.GetIndexerPropertyInfo(
                TargetType, firstColumnName);

            if (_info == null)
                return false;

            _isIndexer = true;

            var parameterType = _info.GetIndexParameters().First().ParameterType;
            _lookUp = Convert.ChangeType(firstColumnName, parameterType);

            return true;
        }

        public override int considerOrder
        {
            get { return ActionOrder.DeepCompare.ToInt32(); }
        }
    }
}
