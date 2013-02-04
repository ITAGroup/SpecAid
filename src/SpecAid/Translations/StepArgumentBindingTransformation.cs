using System.Reflection;
using SpecAid.Base;

namespace SpecAid.Translations
{
    public class StepArgumentBindingTransformation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            return false;  
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return false;
        }

        public int considerOrder
        {
            get { return 99; }
        }

    }
}
