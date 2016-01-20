using System;
using System.Linq;
using System.Reflection;
using SpecAid.Base;
using SpecAid.SetTranslations;
using SpecAid.Translations;
using SpecAid.Extentions;
using SpecAid.Helper;

namespace SpecAid.ColumnActions
{
    public class IndexerSetAction : ColumnAction, ICreatorColumnAction
    {
        private PropertyInfo _info;
        private object _lookUp;

        public IndexerSetAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

            var value = Translator.Translate(_info, tableValue);
            value = SetTranslator.Translate(_info, target, value);

            try
            {
                _info.SetValue(target, value, new object[] { _lookUp });
            }
            catch (ArgumentException e)
            {
                var message = string.Format(
                    "Unable to set value of indexer on {0} to value of \"{1}\" to type {2}",
                    target.GetType(),
                    value == null ? "null" : value.ToString(),
                    _info.PropertyType.FullName);

                throw new Exception(message, e);
            }
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
            get { return ActionOrder.IndexerSet.ToInt32(); }
        }
    }
}
