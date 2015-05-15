using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;
using SpecAid.Helper;

namespace SpecAid.Translations
{
    public class NullableEnumTranslation : ITranslation
    {
        #region Properties

        public int ConsiderOrder
        {
            get
            {
                return TranslationOrder.NullableEnum.ToInt32();
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