using System;

namespace SpecAid.Base
{
    public class TypeConversion
    {

        /// <summary>
        /// Converts the actual value to the expected type if possible
        /// </summary>
        /// <param name="convertee"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static object SafeConvert(object convertee, object expected)
        {
            return (convertee == null) || (expected == null) ? convertee : Convert.ChangeType(convertee, expected.GetType());
        }
    }
}
