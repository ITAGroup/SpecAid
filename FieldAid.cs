using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;

using SpecAid.Base;
using SpecAid.ColumnActions;
using SpecAid.Helper;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecAid
{
    public class FieldAid
    {
        public static T ObjectCreator<T>(string value)
        {
            var objectField = new ObjectField<T>();

            var matchAction = ColumnActionFactory.GetAction<ICreatorColumnAction>(typeof(ObjectField<T>), "field");

            matchAction.GoGoCreateColumnAction(objectField, value);

            return objectField.field;
        }

        public static void ObjectComparer<T>(T actual, string expected)
        {
            var objectField = new ObjectField<T>();
            objectField.field = actual;

            var matchAction = ColumnActionFactory.GetAction<IComparerColumnAction>(typeof(ObjectField<T>), "field");

            var assertResult = matchAction.GoGoCompareColumnAction(objectField, expected);

            Console.WriteLine("Actual: ");
            Console.WriteLine("\t" + assertResult.ActualPrint);
            Console.WriteLine("Expected: ");
            Console.WriteLine("\t" + assertResult.ExpectedPrint);
            Console.WriteLine("Messages: ");

            if (assertResult.IsError)
            {
                Assert.Fail(assertResult.ErrorMessage);
            }
            else
            {
                Console.WriteLine("\t" + "none");
            }
        }
    }
}
