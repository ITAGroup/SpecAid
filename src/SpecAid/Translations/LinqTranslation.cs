using System;
using System.Reflection;
using System.Text.RegularExpressions;
using SpecAid.Base;
using SpecAid.Helper;
using SpecAid.Linq.Dynamic;
using SpecAid.Extentions;
using TechTalk.SpecFlow.Bindings;

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

            var code = tableValue.TrimAlphaOmega();

            code = TagToStringSwapper.Swap(code);

            var linqCallResult = (DynamicLinq.CreateValueExpression<LinqObject, object>(code))(linqObject);

            return linqCallResult;
        }

        public bool UseWhen(PropertyInfo info, string tableValue)
        {
            return tableValue.FirstAndLastBracketsMatch('{', '}'); ;
        }

        public int ConsiderOrder
        {
            get { return TranslationOrder.Linq.ToInt32(); }
        }
    }
}
