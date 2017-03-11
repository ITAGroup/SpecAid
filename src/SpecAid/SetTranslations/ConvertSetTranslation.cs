using System;
using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;
using SpecAid.Helper;

namespace SpecAid.SetTranslations
{
    public class ConvertSetTranslation : ISetTranslation
    {
        public object Do(PropertyInfo info, object target, object newItem)
        {
            var newValue = newItem;
            try
            {
                newValue = Convert.ChangeType(newItem, info.PropertyType);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            // If the convert doesn't work, just use the original value.
            catch (Exception)
            {}

            return newValue;
        }

        public bool UseWhen(PropertyInfo info, object target, object newItem)
        {
            return TypeHelpers.ImplementsIConvertible(info.PropertyType);
        }

        public int ConsiderOrder
        {
            get { return SetTranslationOrder.Convert.ToInt32(); }
        }
    }
}
