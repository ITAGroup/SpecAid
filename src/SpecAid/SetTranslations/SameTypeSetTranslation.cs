using System.Reflection;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.SetTranslations
{
    public class SameTypeSetTranslation : ISetTranslation
    {
        public object Do(PropertyInfo info, object target, object newItem)
        {
            return newItem;
        }

        public bool UseWhen(PropertyInfo info, object target, object newItem)
        {
            return info.PropertyType.IsInstanceOfType(newItem);
        }

        public int ConsiderOrder
        {
            get { return SetTranslationOrder.SameType.ToInt32(); }
        }
    }
}
