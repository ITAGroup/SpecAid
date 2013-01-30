using System;
using System.Reflection;
using SpecAid.Base;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using SpecAid.Helper;
using SpecAid.Linq.Dynamic;

namespace SpecAid.Translations
{
    // Oh No You Didn't
    public class LinqTranslation : ITranslation
    {
        public class LinqObject
        {
            public RecallAid Recall { get; set; }
            public StringAid StringAid { get; set; }
            public IntAid IntAid { get; set; }
        }

        public class StringAid
        {
            public string this[string index]
            {
                get { return FieldAid.ObjectCreator<string>(index); }
            }
        }

        public class IntAid
        {
            public int this[string index]
            {
                get { return FieldAid.ObjectCreator<Int32>(index); }
            }
        }


        public object Do(PropertyInfo info, string tableValue)
        {
            var linqObject = new LinqObject();
            linqObject.Recall = RecallAid.It;
            linqObject.StringAid = new StringAid();
            linqObject.IntAid = new IntAid();

            var code = tableValue.Substring(1, tableValue.Length - 2);

            var linqCallResult = (DynamicLinq.CreateValueExpression<LinqObject, object>(code))(linqObject);

            return linqCallResult;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            if (!tableValue.StartsWith("{"))
                return false;

            if (!tableValue.EndsWith("}"))
                return false;

            return true;
        }

        public int considerOrder
        {
            get { return 98; }
        }
    }
}
