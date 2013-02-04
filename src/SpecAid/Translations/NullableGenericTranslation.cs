using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.ColumnActions;

namespace SpecAid.Translations
{
    public class NullableGenericTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            if (string.IsNullOrWhiteSpace(tableValue))
                return null;

            var innerType = Nullable.GetUnderlyingType(info.PropertyType);

            try
            {
                return Convert.ChangeType(tableValue, innerType);
            }
            catch
            {
                //If we cannot change to the type explicitly then we'll default to the exception when an implicit conversion is attempted.
                return null;
            }
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            var innerType = Nullable.GetUnderlyingType(info.PropertyType);

            return info.PropertyType.IsGenericType && 
                   info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                   SetAction.ImplementsIConvertible(innerType);
        }

        public int considerOrder
        {
            get { return 9; }
        }
    }
}
