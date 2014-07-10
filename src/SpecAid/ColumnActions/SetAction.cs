using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Helper;
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

            try
            {
                if (ImplementsIConvertible(Info.PropertyType))
                    value = Convert.ChangeType(value, Info.PropertyType);
            }
            catch
            {
                //If we cannot change to the type explicitly then we'll default to the exception when an implicit conversion is attempted.
            }

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

        /// <summary>
        /// Does type T implement IConvertible?? 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        internal static bool ImplementsIConvertible(Type t)
        {
            return t.GetInterface(typeof(IConvertible).Name) != null;
        }

        public override int considerOrder
        {
            get { return ActionOrder.Set.ToInt32(); }
        }

    }
}
