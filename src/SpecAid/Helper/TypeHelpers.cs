using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecAid.Helper
{
    public class TypeHelpers
    {
        /// <summary>
        /// Does type T implement IConvertible?? 
        /// </summary>
        internal static bool ImplementsIConvertible(Type t)
        {
            return t.GetInterface(typeof(IConvertible).Name) != null;
        }
    }
}
