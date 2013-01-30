using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecAid.CustomCompare
{
    public static class CustomComparerHelpers
    {
        public static void CompareCollections<T>(IEnumerable<T> expectedList, IEnumerable<T> actualList, CustomComparer<T> comparer)
        {
            HashSet<T> expected = new HashSet<T>(expectedList, comparer);
            HashSet<T> actual = new HashSet<T>(actualList, comparer);

            //we now have only items that didn't match the other list
            expected.ExceptWith(actualList);
            actual.ExceptWith(expectedList);

            StringBuilder errors = new StringBuilder();

            if (expected.Count > 0)
            {
                errors.AppendLine("Found " + expected.Count + " expected results that did not have matching actual results");
                foreach (T record in expected)
                    errors.AppendLine("\t" + comparer.GetFieldEqualValueStringWithSymbolicLink(record));
            }

            if (actual.Count > 0)
            {
                if (errors.Length > 0)
                    errors.AppendLine();
                errors.AppendLine("Found " + actual.Count + " actual results that did not have matching expected results");
                foreach (T record in actual)
                    errors.AppendLine("\t" + comparer.GetFieldEqualValueStringWithSymbolicLink(record));
            }

            if (errors.Length > 0)
                Assert.Fail(errors.ToString());
        }

        public static void CompareCollections<T>(IEnumerable<T> expectedList, IEnumerable<T> actualList, CustomComparer<T> keyComparer, CustomComparer<T> valueComparer)
        {
            if (keyComparer == null)
                throw new Exception("keyComparer cannot be null");

            HashSet<T> expected = new HashSet<T>(expectedList, keyComparer);
            HashSet<T> actual = new HashSet<T>(actualList, keyComparer);

            //we now have only items that didn't match the other list
            expected.ExceptWith(actualList);
            actual.ExceptWith(expectedList);

            StringBuilder errors = new StringBuilder();

            if (expected.Count > 0)
            {
                errors.AppendLine("Found " + expected.Count + " expected results that did not have matching actual results");
                foreach (T record in expected)
                {
                    string stringRepresentation = keyComparer.GetFieldEqualValueStringWithSymbolicLink(record);
                    if (valueComparer != null)
                        stringRepresentation += " " + valueComparer.GetFieldEqualValueStringWithSymbolicLink(record);
                    errors.AppendLine("\t" + stringRepresentation);

                }
            }

            if (actual.Count > 0)
            {
                if (errors.Length > 0)
                    errors.AppendLine();
                errors.AppendLine("Found " + actual.Count + " actual results that did not have matching expected results");
                foreach (T record in actual)
                {
                    string stringRepresentation = keyComparer.GetFieldEqualValueStringWithSymbolicLink(record);
                    if (valueComparer != null)
                        stringRepresentation += " " + valueComparer.GetFieldEqualValueStringWithSymbolicLink(record);
                    errors.AppendLine("\t" + stringRepresentation);
                }
            }

            if (valueComparer != null)
            {
                var expectedItemsThatHaveAMatch = expectedList.Intersect(actualList, keyComparer);
                var actualToActualDict = actualList.ToDictionary(a => a, a => a, keyComparer);

                //remember, all of this is done using the key comparer!
                Dictionary<T, T> expectedToActualMatches = expectedItemsThatHaveAMatch.ToDictionary(e => e, e => actualToActualDict[e], keyComparer);

                //so we now have a dictionary of expectedItems that have a match, to their actual match
                //now we want to compare the expected-actual match with the value comparer instead

                var matchErrorCount = 0;
                StringBuilder matchErrors = new StringBuilder();
                foreach (KeyValuePair<T, T> expectedToActualMatch in expectedToActualMatches)
                {
                    var expectedItem = expectedToActualMatch.Key;
                    var actualItem = expectedToActualMatch.Value;

                    if (!valueComparer.Equals(expectedItem, actualItem))
                    {
                        var matchError = "\t" + (matchErrorCount + 1) + ". Matched Key Values: " + keyComparer.GetFieldEqualValueStringWithSymbolicLink(expectedItem) +
                                         "\r\n\t\tExpected Values: " + valueComparer.GetFieldEqualValueStringWithSymbolicLink(expectedItem) +
                                         "\r\n\t\tActual   Values: " + valueComparer.GetFieldEqualValueStringWithSymbolicLink(actualItem);

                        if (matchErrorCount > 0)
                            matchErrors.AppendLine();

                        matchErrors.Append(matchError);

                        matchErrorCount++;
                    }
                }

                if (matchErrorCount > 0)
                {
                    if (errors.Length > 0)
                        errors.AppendLine();
                    errors.AppendLine("Found " + matchErrorCount + " items that had a match in expected and actual (based on keyComparer), but did not match on valueComparer");
                    errors.Append(matchErrors);
                }
            }

            if (errors.Length > 0)
                Assert.Fail(errors.ToString());
        }

    }
}