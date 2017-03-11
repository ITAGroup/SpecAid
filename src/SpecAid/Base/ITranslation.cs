using System.Reflection;

namespace SpecAid.Base
{
    public interface ITranslation
    {
        int ConsiderOrder {get; }
        object Do(PropertyInfo info, string tableValue);
        bool UseWhen(PropertyInfo info, string tableValue);
    }
}
