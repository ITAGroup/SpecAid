using System.Reflection;

namespace SpecAid.Base
{
    public interface ISetTranslation
    {
        int ConsiderOrder {get; }
        object Do(PropertyInfo info, object target, object newItem);
        bool UseWhen(PropertyInfo info, object target, object newItem);
    }
}
