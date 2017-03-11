using System;
using System.Reflection;
using System.Linq;

namespace SpecAid.Helper
{
    public static class PropertyInfoHelper
    {
        /// <summary>
        /// Returns the PropertyInfo so I don't have to look it back up in the "Do" method
        ///     1.) Tries to find the property by exact name first
        ///     2.) Tries to find the property using a case insensitive compare
        ///     3.) Checks nested interfaces using a case insensitive compare
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static PropertyInfo GetCaseInsensitivePropertyInfo(Type targetType, string columnName)
        {
            PropertyInfo info = null;
            var spaceLessColumnName = columnName.Replace(" ", string.Empty);

            //Find the property based on exact name and return if it's found
            info = targetType.GetProperty(spaceLessColumnName);

            if (info != null)
                return info;

            //Find the property based on a case insensitive compare of the name and return if it's found
            var infos = targetType.GetProperties();

            info =
                infos.SingleOrDefault(
                    x => x.Name.Equals(spaceLessColumnName, StringComparison.InvariantCultureIgnoreCase));

            if (info != null)
                return info;

            //find the property based on a case insensitive compare on a nested interface
            foreach (Type iType in targetType.GetInterfaces())
            {
                infos = iType.GetProperties();
                info =
                    infos.SingleOrDefault(
                        x => x.Name.Equals(spaceLessColumnName, StringComparison.InvariantCultureIgnoreCase));
                if (info != null)
                    return info;
            }

            //Property wasn't found return null
            return null;
        }

        public static PropertyInfo GetIndexerPropertyInfo(Type targetType, string columnName)
        {
            var canidates = targetType
                .GetProperties()
                .Where(x => x.GetIndexParameters().Length == 1)
                .ToArray();

            PropertyInfo theStringParameter = null;

            foreach (var propertyInfo in canidates)
            {
                var indexParameter = propertyInfo.GetIndexParameters().First();
                var indexParameterType = indexParameter.ParameterType;

                // string parm... will always work.
                // so we skip it for other more interesting parms.
                if (indexParameterType == typeof (string))
                {
                    theStringParameter = propertyInfo;
                    continue;
                }

                try
                {
                    // later when the type translate lib is added...
                    // reconsider using that.
                    Convert.ChangeType(columnName, indexParameterType);
                    return propertyInfo;
                }
                catch (Exception)
                {
                    // ignored... because we are treating the try as an if.
                }
            } 

            return theStringParameter;
        }
    }
}