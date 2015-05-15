using System;
using System.Reflection;
using System.Linq;
using SpecAid.Helper;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.Translations
{
    public class DeepLinkTranslation : ITranslation
    {
        public object Do(PropertyInfo info, string tableValue)
        {
            // get the link from recallaid
            // then traverse the object getting each property until the last one
            // then return it's value

            var splits = tableValue.Split('.').ToList();
            var tag = splits[0];

            if (!RecallAid.It.ContainsKey(tag))
                throw new Exception("Could not find tag/link: " + tag);

            var recalledValue = RecallAid.It[tag];

            if (recalledValue == null)
                throw new Exception("Could not find tag/link: " + tableValue);

            object propertyValue = recalledValue;
            string previousPropertyName = tag;

            foreach (var propertyName in splits.Skip(1))
            {
                if (propertyValue == null)
                    throw new Exception(string.Format("Property is null \"{0}\" in tag \"{1}\"", previousPropertyName, tableValue));

                var targetProperty = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(propertyValue.GetType(), propertyName);

                if (targetProperty == null)
                    throw new Exception(string.Format("Could not find property \"{0}\" in tag \"{1}\"", propertyName, tableValue));

                propertyValue = targetProperty.GetValue(propertyValue, null);
                previousPropertyName = propertyName;
            }

            return propertyValue;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            // Tags are in the form #TagName or <<TagName>>
            // Tags can also have Deep-Linked properties using the Tag as a starting point
            // Example:
            //   #Dealer001.SalesDistrict.Code
            //   - or -
            //   <<Dealer001>>.SalesDistrict.Code

            var propertyNames = tableValue.Split('.');

            // 2 = object (1) + property (1)
            if (propertyNames.Length < 2)
                return false;

            var tag = propertyNames[0];
            return TagHelper.IsTag(tag);
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.DeepLink.ToInt32(); }
        }
    }
}
