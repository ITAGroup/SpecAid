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
        public IndexerSetAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        private PropertyInfo Info { get; set; }
        private object LookUp { get; set; }

        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

            var value = Translator.Translate(Info, tableValue);

            value = SetTranslator.Translate(Info, target, value);

            try
            {
                Info.SetValue(target, value, new object[] { LookUp });
            }
            catch (ArgumentException e)
            {
                var message = string.Format("Unable to set value of indexer on {0} to value of \"{1}\" to type {2}",
                    target.GetType(),
                    value == null ? "null" : value.ToString(),
                    Info.PropertyType.FullName);

                throw new Exception(message, e);
            }
        }

        public override bool UseWhen()
        {
            Info = PropertyInfoHelper.GetIndexerPropertyInfo(TargetType, ColumnName);

            if (Info == null)
                return false;

            var parameterType = Info.GetIndexParameters().First().ParameterType;
            LookUp = Convert.ChangeType(ColumnName, parameterType);

            return true;
        }

        public override int considerOrder
        {
            get { return ActionOrder.IndexerSet.ToInt32(); }
        }
    }
}
