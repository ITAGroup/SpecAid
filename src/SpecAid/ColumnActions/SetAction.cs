using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.SetTranslations;
using SpecAid.Translations;
using SpecAid.Extentions;

namespace SpecAid.ColumnActions
{
    //Action for setting the value in the object
    public class SetAction : ColumnAction, ICreatorColumnAction
    {

        public SetAction(Type targetType, string columnName)
            : base(targetType, columnName)
        {
        }

        private PropertyInfo Info { get; set; }

        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

            var value = Translator.Translate(Info, tableValue);

            // Convert the Translated value to the type of the targeted property.
            // Translators guilty of not honoring the PropertyInfo ... Tag, Deep Link, Dates, etcetera

            value = SetTranslator.Translate(Info, target, value);

            try
            {
                Info.SetValue(target, value, null);
            }
            catch (ArgumentException e)
            {
                var message = string.Format("Unable to set value of property {0} on {1} to value of \"{2}\" to type {3}",
                          Info.Name,
                          target.GetType(),
                          value == null ? "null" : value.ToString(),
                           Info.PropertyType.FullName);

                throw new Exception(message, e);
            }
        }

        public override bool UseWhen()
        {
            Info = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(TargetType, ColumnName);

            //could not find the property on the object
            return (Info != null);
        }

        public override int considerOrder
        {
            get { return ActionOrder.Set.ToInt32(); }
        }
    }
}
