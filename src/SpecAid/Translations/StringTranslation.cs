using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Base;

namespace SpecAid.Translations
{
    public class StringTranslation : ITranslation
    {

        public object Do(PropertyInfo info, string tableValue)
        {
            return tableValue.Substring(1,tableValue.Length - 2);
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return tableValue.StartsWith("\"") && tableValue.EndsWith("\"");
        }

        // I am the ultimate override
        public int considerOrder
        {
            get { return 0; }
        }
    }
}
