using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.SetTranslations;
using SpecAid.Translations;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    public class IndexerSetAction : ColumnAction, ICreatorColumnAction
    {
        public IndexerSetAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        private PropertyInfo Info { get; set; }

        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

            var value = Translator.Translate(Info, tableValue);

            value = SetTranslator.Translate(Info, target, value);

            try
            {
                Info.SetValue(target, value, new object[] { ColumnName });
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
            Info = TargetType.GetProperty("Item");

            // no indexer to use
            return (Info != null);
        }

        public override int considerOrder
        {
            get { return ActionOrder.IndexerSet.ToInt32(); }
        }
    }
}
