using System;
using System.Reflection;
using SpecAid.Base;
using System.Text.RegularExpressions;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class DateTranslation : ITranslation
    {

        public object Do(PropertyInfo info, string tableValue)
        {
            var myDatetimeAsString = tableValue.Substring(1,10);
            return DateTime.ParseExact(myDatetimeAsString, "yyyy-MM-dd", null);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            Regex r = new Regex(@"\[\d\d\d\d-\d\d-\d\d\]");
            return r.IsMatch(tableValue);
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.Date.ToInt32(); }
        }
    }
}
