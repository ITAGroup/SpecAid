using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using SpecAid.Base;
using SpecAid.ColumnActions;
using SpecAid.CustomCompare;
using SpecAid.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecAid
{
    public static class TableAid
    {
        #region Public ObjectCreator 
        public static IEnumerable<T> ObjectCreator<T>(Table table) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, null, null, null, null);
        }

        public static IEnumerable<T> ObjectCreator<T>(Table table, Func<T> defaultValue)
        {
            return ObjectCreatorUpdaterInternal<T>(table, defaultValue, null, null, null);
        }

        public static IEnumerable<T> ObjectCreator<T>(Table table, Action<TableRow, T> postFillActions) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, null, null, postFillActions, null);
        }

        public static IEnumerable<T> ObjectCreator<T>(Table table, Func<T> defaultValue, Action<TableRow, T> postFillActions) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, defaultValue, null, postFillActions, null);
        }

        public static T ObjectCreatorOne<T>(Table table) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, null, null, null, null).FirstOrDefault();
        }

        public static T ObjectCreatorOne<T>(Table table, Func<T> defaultValue) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, defaultValue, null, null, null).FirstOrDefault();
        }

        public static T ObjectCreatorOne<T>(Table table, Action<TableRow, T> postFillActions)
        {
            return ObjectCreatorUpdaterInternal<T>(table, null, null, postFillActions, null).FirstOrDefault();
        }

        public static T ObjectCreatorOne<T>(Table table, Func<T> defaultValue, Action<TableRow, T> postFillActions) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, defaultValue, null, postFillActions, null).FirstOrDefault();
        }


        #endregion

        #region Public ObjectUpdater
        public static IEnumerable<T> ObjectUpdater<T>(Table table, Func<TableRow, T> objectFinder) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, null, objectFinder, null, null);
        }

        public static IEnumerable<T> ObjectUpdater<T>(Table table, Func<TableRow, T> objectFinder, Action<TableRow, T> postMatchActions) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, null, objectFinder, postMatchActions, null);
        }

        public static IEnumerable<T> ObjectUpdaterOne<T>(Table table,  T data, Action<TableRow, T> postMatchActions) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, () => { return data; }, null, postMatchActions, null);
        }

        public static IEnumerable<T> ObjectUpdaterOne<T>(Table table, T data) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, () => { return data; }, null, null, null);
        }
        #endregion

        #region Public ObjectComparer

        public static void ObjectComparer<T>(Table table, IEnumerable<T> data)
        {
            ObjectComparerInternal<T>(table, data, null, null);
        }

        public static void ObjectComparer<T>(Table table, IEnumerable<T> data, IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerInternal<T>(table, data, null, columnOverrides);
        }

        public static void ObjectComparerOne<T>(Table table, T data)
        {
            ObjectComparerInternalOne<T>(table, data, null, null);
        }

        public static void ObjectComparerOne<T>(Table table, T data, IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerInternalOne<T>(table, data, null, columnOverrides);
        }

        public static void ObjectComparer<T>(Table table, IEnumerable<T> data, Action<TableRow, T> postCompareActions)
        {
            ObjectComparerInternal<T>(table, data, postCompareActions, null);
        }

        public static void ObjectComparer<T>(Table table, Func<TableRow, T> objectFinder)
        {
            ObjectComparerInternal<T>(table, objectFinder, null, null);
        }

        public static void ObjectComparer<T>(Table table, Func<TableRow, T> objectFinder, Action<TableRow, T> postCompareActions)
        {
            ObjectComparerInternal<T>(table, objectFinder, postCompareActions, null);
        }

        #endregion


        private static IEnumerable<T> ObjectCreatorUpdaterInternal<T>(Table VOHtable, Func<T> defaultValue, Func<TableRow, T> objectFinder, Action<TableRow, T> postMatchActions, IEnumerable<ColumnToActionContainer<ICreatorColumnAction>> columnOverrides)
        {
            var table = VerticalToHorizonal(VOHtable);

            //set up the return value 
            var ret = new List<T>();

            //hold which column maps to which property
            var matches = ColumnActionFactory.GetActionsFromColumns<ICreatorColumnAction>(table, typeof(T), columnOverrides);

            Dictionary<T, TableRow> valueToRow = new Dictionary<T, TableRow>();

            //flip through each row and setup the data
            for (var i = 0; i < table.RowCount; i++)
            {
                T obj = default(T);

                //get the default value from the given method if specified
                if (defaultValue != null)
                {
                    obj = defaultValue();
                }

                //go find one that exists.  If one exists.
                else if (objectFinder != null)
                {
                    obj = objectFinder(table.Rows[i]);
                    // can't set anything on null anyway.
                    if (obj == null)
                        continue;
                }
                else
                {
                    // Be like Assist too pop Constructor.
                    // Until then

                    if (!ObjectHelper.ThisTypeHasADefaultConstructor<T>())
                        throw new Exception("Type needs a Default Constructor if you don't provide a method for creating one.");

                    obj = ObjectHelper.CreateObjectWithTheDefaultConstructor<T>();
                }

                //collect the errors so we can report a little nicer
                try
                {
                    //run through each column and set the matching prop
                    foreach (var item in matches)
                        item.MatchAction.GoGoCreateColumnAction(obj, table.Rows[i][item.ColumnIndex.Value]);
                }
                catch (AssertFailedException ex)
                {
                    throw new AssertFailedException("Error on row: " + i, ex);
                }

                if (postMatchActions != null)
                {
                    postMatchActions(table.Rows[i], obj);
                }

                //add this item to our return collection
                ret.Add(obj);
                valueToRow.Add(obj, table.Rows[i]);
            }

            // Ignore ScenarioContext if we are not using it,
            //   for instance in a Manual Test on ColumnActions
            if (ScenarioContext.Current != null)
            {
                RecallAid.It[table.GetHashCode().ToString()] = valueToRow;
            }

            //return the collection of updated items
            return ret;
        }

        private static void ObjectComparerInternalOne<T>(Table VOHtable, T dataItem, Action<TableRow, T> postCompareActions, IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            var table = VerticalToHorizonal(VOHtable);

            if (table.RowCount != 1)
            {
                Assert.Fail("A direct compare requires one and only one Specflow Row.");
            }

            var compareTableResult = new CompareTableResult();
            compareTableResult.InitCompare(table, 1);

            // hold which column maps to which property
            var columnActions = ColumnActionFactory.GetActionsFromColumns<IComparerColumnAction>(table, typeof(T), columnOverrides);

            var row = table.Rows[0];
            var compareRowResult = ObjectComparerInternalRow<T>(columnActions, row, dataItem);
            compareTableResult.AddRowResult(0, 0, compareRowResult, true);

            compareTableResult.FinalAnalyst();

            // Perform Printing
            Console.WriteLine(compareTableResult.PrintMeSpecflowStyle());

            compareTableResult.TheAssert();

            // trigger postAction if needed.
            if (compareRowResult.totalErrors == 0)
            {
                if (postCompareActions != null)
                {
                    postCompareActions(table.Rows[0], dataItem);
                }
            }
        }

        private static void ObjectComparerInternal<T>(Table table, Func<TableRow, T> objectFinder, Action<TableRow, T> postCompareActions, IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            var compareTableResult = new CompareTableResult();
            compareTableResult.InitCompare(table, table.RowCount);

            // hold which column maps to which property
            var columnActions = ColumnActionFactory.GetActionsFromColumns<IComparerColumnAction>(table, typeof(T), columnOverrides);

            // flip through each row
            for (var tableRowIndex = 0; tableRowIndex < table.RowCount; tableRowIndex++)
            {
                var row = table.Rows[tableRowIndex];

                var dataItem = objectFinder(row);

                // can't set anything on null anyway.
                if (dataItem == null)
                {
                    throw new AssertFailedException("Object Not found in Row " + tableRowIndex);
                }

                // Compare It
                var compareRowResult = ObjectComparerInternalRow<T>(columnActions, row, dataItem);
                compareTableResult.AddRowResult(tableRowIndex, tableRowIndex, compareRowResult, true);

                if (compareRowResult.totalErrors == 0)
                {
                    if (postCompareActions != null)
                    {
                        postCompareActions(table.Rows[tableRowIndex], dataItem);
                    }
                }

            }
            compareTableResult.FinalAnalyst();

            // Perform Printing
            Console.WriteLine(compareTableResult.PrintMeSpecflowStyle());

            compareTableResult.TheAssert();
        }

        private static void ObjectComparerInternal<T>(Table table, IEnumerable<T> dataList, Action<TableRow, T> postCompareActions, IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            if (dataList == null)
            {
                throw new Exception("Actual is Null.  TableAid can't compare a table against null.");
            }

            var compareTableResult = new CompareTableResult();
            compareTableResult.InitCompare(table,dataList.Count());

            // hold which column maps to which property
            var columnActions = ColumnActionFactory.GetActionsFromColumns<IComparerColumnAction>(table, typeof(T), columnOverrides);

            // flip through each row
            for (var tableRowIndex = 0; tableRowIndex < table.RowCount; tableRowIndex++)
            {
                var IsMatch = false;
   
                // And each data
                for (var dataIndex = 0; dataIndex < dataList.Count(); dataIndex++)
                {
                    // Has a match Happened
                    if (compareTableResult.DoesDataHaveMatch(dataIndex))
                        continue;

                    // Ready the Compare
                    var row = table.Rows[tableRowIndex];
                    var dataItem = dataList.ElementAt(dataIndex);

                    // Compare It
                    var compareRowResult = ObjectComparerInternalRow<T>(columnActions, row, dataItem);

                    IsMatch = (compareRowResult.totalErrors == 0);

                    // This makes the Match Happen
                    compareTableResult.AddRowResult(tableRowIndex, dataIndex, compareRowResult, IsMatch);

                    if (compareRowResult.totalErrors == 0)
                    {
                        if (postCompareActions != null)
                        {
                            postCompareActions(table.Rows[tableRowIndex], dataItem);
                        }

                        break; // We have a match.  Stop looping data.
                    }
                }

                // Add the missing Table Records
                if (IsMatch == false)
                {
                    var row = table.Rows[tableRowIndex];
                    var compareRowResult = ObjectComparerInternalRow(columnActions, row);
                    compareTableResult.AddRowResult(tableRowIndex, int.MaxValue, compareRowResult, false);
                }
            }

            // Add the missing Data Records
            for (var dataIndex = 0; dataIndex < dataList.Count(); dataIndex++)
            {
                // Has a match Happened
                if (compareTableResult.DoesDataHaveMatch(dataIndex))
                    continue;

                // No?  Well add a blank to the compare.
                var dataItem = dataList.ElementAt(dataIndex);
                var compareRowResult = ObjectComparerInternalRow(columnActions, dataItem);
                compareTableResult.AddRowResult(int.MaxValue, dataIndex, compareRowResult, false);
            }

            compareTableResult.FinalAnalyst();

            // Perform Printing
            Console.WriteLine(compareTableResult.PrintMeSpecflowStyle());

            compareTableResult.TheAssert();
        }

        private static CompareRowResult ObjectComparerInternalRow<T>(IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnActions, TableRow row, T data)
        {
            var rowResult = new CompareRowResult();

            //run through each column and set the matching prop
            foreach (var item in columnActions)
            {
                var compareColumnResult = item.MatchAction.GoGoCompareColumnAction(data, row[item.ColumnIndex.Value]);

                rowResult.columnResults.Add(compareColumnResult);
            }

            return rowResult;
        }

        private static CompareRowResult ObjectComparerInternalRow(IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnActions, TableRow row)
        {
            var rowResult = new CompareRowResult();

            //run through each column and set the matching prop
            foreach (var item in columnActions)
            {
                var compareColumnResult = item.MatchAction.GoGoCompareColumnAction(row[item.ColumnIndex.Value]);

                rowResult.columnResults.Add(compareColumnResult);
            }

            return rowResult;
        }

        private static CompareRowResult ObjectComparerInternalRow<T>(IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnActions, T data)
        {
            var rowResult = new CompareRowResult();

            //run through each column and set the matching prop
            foreach (var item in columnActions)
            {
                var compareColumnResult = item.MatchAction.GoGoCompareColumnAction(data);

                rowResult.columnResults.Add(compareColumnResult);
            }

            return rowResult;
        }



        /// <summary>
        /// Output style:
        ///   FieldName1 = FieldValue1 (tag), FieldName1 = FieldValue2 (tag)
        /// </summary>
        public static string ActualCollectionFancyTostring<T>(Table table, IEnumerable<T> actual)
        {
            StringBuilder actualStringListing = new StringBuilder();
            actualStringListing.AppendLine();
            actualStringListing.AppendLine("Actual:" );

            var comparer = TableAid.ComparerCreator<T>(table);

            foreach (T record in actual)
            {
                actualStringListing.AppendLine("\t" + comparer.GetFieldEqualValueStringWithSymbolicLink(record));
            }

            actualStringListing.AppendLine();

            return actualStringListing.ToString();
        }

        /// <summary>
        /// Output style:
        ///   | FieldName1  | FieldName2  |
        ///   | FieldValue1 | FieldValue2 |
        /// </summary>
        public static string ActualCollectionSpecflowFancyTostring<T>(Table table, IEnumerable<T> actual)
        {
            return ActualCollectionWithMatchesSpecflowFancyTostring<T>(table, actual, null);
        }

        /// <summary>
        /// Output style:
        ///   | FieldName1  | FieldName2  |
        /// </summary>
        public static string ActualObjectWithMatchesSpecflowFancyTostring<T>(Table table, T actual)
        {
            var actualAsCollection = new List<T>();
            actualAsCollection.Add(actual);

            var dataToTableRowMatches = new Dictionary<int, int>();
            dataToTableRowMatches.Add(0,0);

            return ActualCollectionWithMatchesSpecflowFancyTostring(table, actualAsCollection, dataToTableRowMatches);
        }

        /// <summary>
        /// Output style:
        ///   | FieldName1  | FieldName2  |
        ///   | FieldValue1 | FieldValue2 |
        /// </summary>
        public static string ActualCollectionWithMatchesSpecflowFancyTostring<T>(Table table, IEnumerable<T> actual, Dictionary<int, int> dataToTableRowMatches)
        {
            StringBuilder actualStringListing = new StringBuilder();
            actualStringListing.AppendLine();
            actualStringListing.AppendLine("Actual:");

            // Get Header and Column data in Property order.

            var comparer = TableAid.ComparerCreator<T>(table);

            var output = new List<List<string>>();

            output.Add(comparer.GetHeaderValuesInPropertyOrder());

            foreach (T record in actual)
            {
                output.Add(comparer.GetColumnValuesInPropertyOrder(record));
            }

            if (output.Count < 2)
                return "Actual: Collection is Empty";

            // Add Match List if Avalible.

            if (dataToTableRowMatches != null)
            {
                // Add Matched Column
                output[0].Insert(0, "Matches");

                for (int i = 1 /* Skip the Header*/ ; i < output.Count; i++)
                {
                    int zeroRelativeDataIndex = i - 1;

                    if (dataToTableRowMatches.ContainsKey(zeroRelativeDataIndex))
                    {
                        int oneRelativeTableRowIndex = dataToTableRowMatches[zeroRelativeDataIndex] + 1;
                        string tableRowMatch = oneRelativeTableRowIndex.ToString();
                        output[i].Insert(0, tableRowMatch);
                    }
                    else
                    {
                        // Bump the column over one
                        output[i].Insert(0, "");
                    }
                }
            }

            var numberOfTotalColumns = new int[output[0].Count];

            // Get max width of each column
            foreach (var outLine in output)
            {
                for (int i = 0; i < outLine.Count; i++)
                {
                    if (numberOfTotalColumns[i] < outLine[i].Length)
                        numberOfTotalColumns[i] = outLine[i].Length;
                }
            }

            // Create pipe delimited fixed with output
            foreach (var outLine in output)
            {
                actualStringListing.Append("\t");
                actualStringListing.Append("| ");
                for (int i = 0; i < outLine.Count; i++)
                {
                    actualStringListing.Append(outLine[i].PadRight(numberOfTotalColumns[i]));
                    actualStringListing.Append(" | ");
                }
                actualStringListing.AppendLine();
            }
            return actualStringListing.ToString();
        }



        /// <summary>
        ///   Used to create a Lambda Member Lookup based on Type and Specflow Table.
        ///   Resulting CustomComparer can be used in Collection Comparer and Fancy Printers
        /// </summary>
        private static CustomComparer<T> ComparerCreator<T>(Table table)
        {
            var contentComparer = CustomComparer<T>.CreateNew();

            for (var i = 0; i < table.Header.Count(); i++)
            {
                var propertyInfo = PropertyInfoHelper.GetCaseInsensitivePropertyInfo(typeof(T), table.Header.ElementAt(i));

                if (propertyInfo != null)
                {
                    // One dynamic property on the fly
                    var entityParam = Expression.Parameter(typeof(T), "e");
                    var memberExpressionReal = Expression.MakeMemberAccess(entityParam, propertyInfo);
                    var memberExpressionObj = Expression.Convert(memberExpressionReal, typeof(object));
                    var exp = Expression.Lambda<Func<T, object>>(memberExpressionObj, entityParam);

                    contentComparer.Add(exp);
                }
            }

            return contentComparer;
        }

        private static Table VerticalToHorizonal(Table table)
        {
            //| Field | Value             |
            if (table.Header.Count != 2)
                return table;

            if (table.Header.ElementAt(0) != "Field")
                return table;

            if (table.Header.ElementAt(1) != "Value")
                return table;

            var trans = new Dictionary<string, string>();

            foreach (var tableRow in table.Rows)
            {
                var header = tableRow["Field"];
                var value = tableRow["Value"];
                trans.Add(header,value);
            }

            var newTable = new Table(trans.Keys.ToArray());
            newTable.AddRow(trans);

            return newTable;
        }
    }
}
