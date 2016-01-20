using System.Reflection;
using SpecAid.Base;

namespace SpecAidTests.Vaporware
{
    public class Informant
    {
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class InformantTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            var informant = new Informant();
            informant.Identity = tableValue;
            return informant;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return (info.PropertyType == typeof(Informant));
        }

        public int ConsiderOrder
        {   // Tag is 60.  Must be after Tag.
            get { return 120; }
        }
    }
}
