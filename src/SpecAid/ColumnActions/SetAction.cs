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
        private PropertyInfo _info;

        public SetAction(Type targetType, string columnName)
            : base(targetType, columnName) { }

        public void GoGoCreateColumnAction(object target, string tableValue)
        {
            if (tableValue == ConstantStrings.IgnoreCell)
                return;

            var value = Translator.Translate(_info, tableValue);

            // Convert the Translated value to the type of the targeted property.
            // Translators guilty of not honoring the PropertyInfo ... Tag, Deep Link, Dates, etcetera

            value = SetTranslator.Translate(_info, target, value);

            try
            {
                _info.SetValue(target, value, null);
            }
            catch (ArgumentException e)
            {
                var message = string.Format(
                    "Unable to set value of property {0} on {1} to value of \"{2}\" to type {3}",
                    _info.Name,
                    target.GetType(),
                    value == null ? "null" : value.ToString(),
                    _info.PropertyType.FullName);

                throw new Exception(message, e);
            }
        }

        public override bool UseWhen()
        {
            _info = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(TargetType, ColumnName);

            //could not find the property on the object
            return (_info != null);
        }

        public override int considerOrder
        {
            get { return ActionOrder.Set.ToInt32(); }
        }
    }
}
