using System.Reflection;

namespace SpecAid.Base
{
    public interface ITranslation
    {
        int considerOrder {get; }
        object Do(PropertyInfo info, string tableValue);
        bool UseWhen(PropertyInfo info, string tableValue);
    }
}
