using System;
using System.Reflection;
using System.Text.RegularExpressions;
using SpecAid.Base;
using SpecAid.Extentions;

namespace SpecAid.SetTranslations
{
    public class GuidToStringSetTranslation : ISetTranslation
    {
        public object Do(PropertyInfo info, object target, object newItem)
        {
            var targetGuid = string.Empty;

            try
            {
                targetGuid = (string)info.GetValue(target, null);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            // If we can't pull the guid we will just guess.
            catch (Exception)
            {}

            if (IsUpperCaseStringGuid(targetGuid))
                return newItem.ToString().ToUpper();
            else
                return newItem.ToString().ToLower();
        }

        private bool IsUpperCaseStringGuid(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                return false;

            return Regex.Match(guid, "[ABCDEF]").Success;
        }

        public bool UseWhen(PropertyInfo info, object target, object newItem)
        {
            if (newItem == null)
                return false;

            if (!(newItem is Guid))
                return false;

            if (!(info.PropertyType == typeof (String)))
                return false;

            return true;
        }

        public int ConsiderOrder
        {
            get { return SetTranslationOrder.GuidToString.ToInt32(); }
        }
    }
}
