using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class NullableEnumTranslation : ITranslation
    {
        #region Properties

        public int considerOrder
        {
            get
            {
                return TranslationOrder.NullableGeneric.ToInt32();
            }
        }

        #endregion

        #region Public Methods

        public object Do(PropertyInfo info, string tableValue)
        {
            if (string.IsNullOrWhiteSpace(tableValue))
                return null;

            var innerType = Nullable.GetUnderlyingType(info.PropertyType);

            return Enum.Parse(innerType, tableValue, true);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            var innerType = Nullable.GetUnderlyingType(info.PropertyType);

            if (innerType == null)
                return false;

            return innerType.IsEnum;
        }

        #endregion
    }
}