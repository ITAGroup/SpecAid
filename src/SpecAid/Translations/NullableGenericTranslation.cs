﻿using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.ColumnActions;
using SpecAid.Extentions;
using SpecAid.Helper;

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
                   TypeHelpers.ImplementsIConvertible(innerType);
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.NullableGeneric.ToInt32(); }
        }
    }
}
