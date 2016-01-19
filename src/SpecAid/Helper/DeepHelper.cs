using System;
using System.Linq;

namespace SpecAid.Helper
{
    public static class DeepHelper
    {
        public static bool IsDeep(string columnName)
        {
            // no dots.  no deeplink
            return columnName.Contains('.');
        }

        public static ColumnNameParts SplitColumnName(string columnName)
        {
            var propertyNames = columnName.Split(new[] { '.' }, 2);

            if (propertyNames.Count() <= 1)
                throw new Exception(string.Format("Can not find any property represented by deep-binding syntax: \"{0}\"", columnName));

            return new ColumnNameParts
            {
                FirstColumn = propertyNames[0],
                OtherColumns = propertyNames[1]
            };
        }
    }

    public class ColumnNameParts
    {
        public string FirstColumn { get; set; }
        public string OtherColumns { get; set; }
    }
}
