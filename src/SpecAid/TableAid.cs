using System;
using System.Collections.Generic;
using System.Linq;
using SpecAid.Base;
using SpecAid.ColumnActions;
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

        public static IEnumerable<T> ObjectCreator<T>(
            Table table, 
            Action<TableRow, T> postFillActions, 
            IEnumerable<ColumnToActionContainer<ICreatorColumnAction>> columnOverrides)
        {
            return ObjectCreatorUpdaterInternal<T>(table, null, null, postFillActions, columnOverrides);
        }

        public static IEnumerable<T> ObjectCreator<T>(
            Table table, 
            Func<T> defaultValue, 
            Action<TableRow, T> postFillActions) 
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

        public static T ObjectCreatorOne<T>(
            Table table, 
            Func<T> defaultValue, 
            Action<TableRow, T> postFillActions) 
        {
            return ObjectCreatorUpdaterInternal<T>(
                table, 
                defaultValue, 
                null, 
                postFillActions, 
                null).FirstOrDefault();
        }


        #endregion

        #region Public ObjectUpdater
        public static IEnumerable<T> ObjectUpdater<T>(Table table, Func<TableRow, T> objectFinder) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, null, objectFinder, null, null);
        }

        public static IEnumerable<T> ObjectUpdater<T>(
            Table table, 
            Func<TableRow, T> objectFinder, 
            Action<TableRow, T> postMatchActions) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, null, objectFinder, postMatchActions, null);
        }

        public static IEnumerable<T> ObjectUpdaterOne<T>(
            Table table,
            T data,
            Action<TableRow, T> postMatchActions) 
        {
            return ObjectCreatorUpdaterInternal<T>(
                table, 
                () => { return data; }, 
                null, 
                postMatchActions, 
                null);
        }

        public static IEnumerable<T> ObjectUpdaterOne<T>(Table table, T data) 
        {
            return ObjectCreatorUpdaterInternal<T>(table, () => { return data; }, null, null, null);
        }
        #endregion

        #region Public ObjectComparer
        
        // |        | table | table, overrides | table, postactions | table, overrides, postaction |
        // | full   | B2    | C2               | D2                 | E2                           |
        // | sorted | B3    | C3               | D3                 | E3                           |
        // | find   | B4    | C4               | D4                 | E4                           |
        // | recall | B5    | C5               | D5                 | E5                           |
        // | one    | B6    | C6               | D6                 | E6                           |

        // B2
        public static void ObjectComparer<T>(Table table, IEnumerable<T> data)
        {
            ObjectComparerInternal<T>(table, data, null, null);
        }

        // C2
        public static void ObjectComparer<T>(
            Table table, 
            IEnumerable<T> data, 
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerInternal<T>(table, data, null, columnOverrides);
        }

        // D2
        public static void ObjectComparer<T>(
            Table table,
            IEnumerable<T> data,
            Action<TableRow, T> postCompareActions)
        {
            ObjectComparerInternal<T>(table, data, postCompareActions, null);
        }

        // E2
        public static void ObjectComparer<T>(
            Table table,
            IEnumerable<T> data,
            Action<TableRow, T> postCompareActions,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerInternal<T>(table, data, postCompareActions, columnOverrides);
        }

        // B3
        public static void ObjectComparerSorted<T>(Table table, IEnumerable<T> data)
        {
            ObjectComparerInternalSorted<T>(table, data, null, null);
        }

        // C3
        public static void ObjectComparerSorted<T>(
            Table table,
            IEnumerable<T> data,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerInternalSorted<T>(table, data, null, columnOverrides);
        }

        // D3
        public static void ObjectComparerSorted<T>(
            Table table,
            IEnumerable<T> data,
            Action<TableRow, T> postCompareActions)
        {
            ObjectComparerInternalSorted<T>(table, data, postCompareActions, null);
        }

        // E3
        public static void ObjectComparerSorted<T>(
            Table table,
            IEnumerable<T> data,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides,
            Action<TableRow, T> postCompareActions)
        {
            ObjectComparerInternalSorted<T>(table, data, postCompareActions, columnOverrides);
        }

        // B4
        public static void ObjectComparer<T>(Table table, Func<TableRow, T> objectFinder)
        {
            ObjectComparerWithFinderInternal<T>(table, objectFinder, null, null);
        }

        // C4
        public static void ObjectComparer<T>(
            Table table,
            Func<TableRow, T> objectFinder,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerWithFinderInternal<T>(table, objectFinder, null, columnOverrides);
        }

        // D4
        public static void ObjectComparer<T>(
            Table table,
            Func<TableRow, T> objectFinder,
            Action<TableRow, T> postCompareActions)
        {
            ObjectComparerWithFinderInternal<T>(table, objectFinder, postCompareActions, null);
        }

        // E4
        public static void ObjectComparer<T>(
            Table table,
            Func<TableRow, T> objectFinder,
            Action<TableRow, T> postCompareActions,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerWithFinderInternal<T>(table, objectFinder, postCompareActions, IgnoreColumnRecallList());
        }

        // B5
        public static void ObjectComparerRecall<T>(Table table)
        {
            var overrides = new List<ColumnToActionContainer<IComparerColumnAction>> { IgnoreColumnRecall() };
            ObjectComparerWithFinderInternal<T>(table, RecallFinder<T>(), null, overrides);
        }

        // C5
        public static void ObjectComparerRecall<T>(
            Table table,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            var overrides = columnOverrides.ToList();
            overrides.Add(IgnoreColumnRecall());
            ObjectComparerWithFinderInternal<T>(table, RecallFinder<T>(), null, overrides);
        }

        // D5
        public static void ObjectComparerRecall<T>(
            Table table,
            Action<TableRow, T> postCompareActions)
        {
            ObjectComparerWithFinderInternal<T>(table, RecallFinder<T>(), postCompareActions, IgnoreColumnRecallList());
        }

        // E5
        public static void ObjectComparerRecall<T>(
            Table table,
            Action<TableRow, T> postCompareActions,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerWithFinderInternal<T>(table, RecallFinder<T>(), postCompareActions, columnOverrides);
        }

        private static Func<TableRow, T> RecallFinder<T>()
        {
            return (row)=>
                {
                    if (row.ContainsKey("Recall"))
                    {
                        var tag = row["Recall"];
                        return (T)RecallAid.It[tag];
                    }
                    return default(T);
                };
        }

        private static List<ColumnToActionContainer<IComparerColumnAction>> IgnoreColumnRecallList()
        {
            var overrides = new List<ColumnToActionContainer<IComparerColumnAction>> { IgnoreColumnRecall() };
            return overrides;
        }

        private static ColumnToActionContainer<IComparerColumnAction> IgnoreColumnRecall()
        {
            var anOverride = new ColumnToActionContainer<IComparerColumnAction>();
            anOverride.ColumnName = "Recall";
            anOverride.MatchAction = new IgnoreAction(null, "Recall");
            return anOverride;
        }

        // B6
        public static void ObjectComparerOne<T>(Table table, T data)
        {
            ObjectComparerInternalOne<T>(table, data, null, null);
        }

        // C6
        public static void ObjectComparerOne<T>(
            Table table, 
            T data, 
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerInternalOne<T>(table, data, null, columnOverrides);
        }

        // D6
        public static void ObjectComparerOne<T>(
            Table table,
            T data,
            Action<TableRow, T> postCompareActions)
        {
            ObjectComparerInternalOne<T>(table, data, postCompareActions, null);
        }

        // E6
        public static void ObjectComparerOne<T>(
            Table table,
            T data,
            Action<TableRow, T> postCompareActions,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            ObjectComparerInternalOne<T>(table, data, postCompareActions, columnOverrides);
        }

        #endregion

        private static IEnumerable<T> ObjectCreatorUpdaterInternal<T>(
            Table verticalOrHorizontalTable, 
            Func<T> defaultValue, 
            Func<TableRow, T> objectFinder, 
            Action<TableRow, T> postMatchActions, 
            IEnumerable<ColumnToActionContainer<ICreatorColumnAction>> columnOverrides)
        {
            var table = VerticalToHorizonal(verticalOrHorizontalTable);

            //set up the return value 
            var result = new List<T>();

            //hold which column maps to which property
            var matches = ColumnActionFactory.GetActionsFromColumns(table, typeof(T), columnOverrides);

            var valueToRow = new Dictionary<T, TableRow>();

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
                        throw new Exception(
                            "Type needs a Default Constructor if you don't provide a method for creating one.");

                    obj = ObjectHelper.CreateObjectWithTheDefaultConstructor<T>();
                }

                //collect the errors so we can report a little nicer
                try
                {
                    //run through each column and set the matching prop
                    foreach (var item in matches)
                        item.MatchAction.GoGoCreateColumnAction(
                            obj, table.Rows[i][item.ColumnIndex.Value]);
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
                result.Add(obj);
                valueToRow.Add(obj, table.Rows[i]);
            }

            // Ignore ScenarioContext if we are not using it,
            //   for instance in a Manual Test on ColumnActions
            if (ScenarioContext.Current != null)
            {
                RecallAid.It[table.GetHashCode().ToString()] = valueToRow;
            }

            //return the collection of updated items
            return result;
        }

        private static void ObjectComparerInternalOne<T>(
            Table verticalOrHorizontalTable, 
            T dataItem, 
            Action<TableRow, T> postCompareActions, 
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            var table = VerticalToHorizonal(verticalOrHorizontalTable);

            if (table.RowCount != 1)
            {
                Assert.Fail("A direct compare requires one and only one Specflow Row.");
            }

            var compareTableResult = new CompareTableResult();
            compareTableResult.InitCompare(table, 1);

            // hold which column maps to which property
            var columnActions = ColumnActionFactory.GetActionsFromColumns(
                table, typeof(T), columnOverrides);

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

        private static void ObjectComparerWithFinderInternal<T>(
            Table table,
            Func<TableRow, T> objectFinder,
            Action<TableRow, T> postCompareActions,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            var compareTableResult = new CompareTableResult();
            compareTableResult.InitCompare(table, table.RowCount);

            // hold which column maps to which property
            var columnActions = ColumnActionFactory.GetActionsFromColumns(
                table, typeof(T), columnOverrides);

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

        private static void ObjectComparerInternalSorted<T>(
            Table table,
            IEnumerable<T> dataList,
            Action<TableRow, T> postCompareActions,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            var compareTableResult = new CompareTableResult();
            compareTableResult.InitCompare(table, dataList.Count());

            // hold which column maps to which property
            var columnActions = ColumnActionFactory.GetActionsFromColumns(
                table, typeof(T), columnOverrides);

            var actualData = dataList.ToList();

            // flip through each row
            for (var tableRowIndex = 0; tableRowIndex < table.RowCount; tableRowIndex++)
            {
                var row = table.Rows[tableRowIndex];

                // Test for null
                if (tableRowIndex >= actualData.Count)
                {
                    var noRowCompareRowResult = ObjectComparerInternalRow(columnActions, row);
                    compareTableResult.AddRowResult(
                        tableRowIndex, int.MaxValue, noRowCompareRowResult, false);
                    continue;
                }

                var dataItem = actualData.ElementAt(tableRowIndex);

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

            for (var dataIndex = table.RowCount; dataIndex < dataList.Count(); dataIndex++)
            {
                var dataItem = dataList.ElementAt(dataIndex);
                var compareRowResult = ObjectComparerInternalRow(columnActions, dataItem);
                compareTableResult.AddRowResult(int.MaxValue, dataIndex, compareRowResult, false);
            }

            compareTableResult.FinalAnalyst();

            // Perform Printing
            Console.WriteLine(compareTableResult.PrintMeSpecflowStyle());

            compareTableResult.TheAssert();
        }

        private static void ObjectComparerInternal<T>(
            Table table,
            IEnumerable<T> dataList,
            Action<TableRow, T> postCompareActions,
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnOverrides)
        {
            if (dataList == null)
            {
                throw new Exception("Actual is Null.  TableAid can't compare a table against null.");
            }

            var compareTableResult = new CompareTableResult();
            compareTableResult.InitCompare(table,dataList.Count());

            // hold which column maps to which property
            var columnActions = ColumnActionFactory.GetActionsFromColumns(
                table, typeof(T), columnOverrides);

            // flip through each row
            for (var tableRowIndex = 0; tableRowIndex < table.RowCount; tableRowIndex++)
            {
                var isMatch = false;
   
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

                    isMatch = (compareRowResult.totalErrors == 0);

                    // This makes the Match Happen
                    compareTableResult.AddRowResult(
                        tableRowIndex, dataIndex, compareRowResult, isMatch);

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
                if (isMatch == false)
                {
                    var row = table.Rows[tableRowIndex];
                    var compareRowResult = ObjectComparerInternalRow(columnActions, row);
                    compareTableResult.AddRowResult(
                        tableRowIndex, int.MaxValue, compareRowResult, false);
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

        private static CompareRowResult ObjectComparerInternalRow<T>(
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnActions,
            TableRow row,
            T data)
        {
            var rowResult = new CompareRowResult();

            //run through each column and set the matching prop
            foreach (var item in columnActions)
            {
                var compareColumnResult = item.MatchAction.GoGoCompareColumnAction(
                    data, row[item.ColumnIndex.Value]);

                rowResult.columnResults.Add(compareColumnResult);
            }

            return rowResult;
        }

        private static CompareRowResult ObjectComparerInternalRow(
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnActions,
            TableRow row)
        {
            var rowResult = new CompareRowResult();

            //run through each column and set the matching prop
            foreach (var item in columnActions)
            {
                var compareColumnResult = item.MatchAction.GoGoCompareColumnAction(
                    row[item.ColumnIndex.Value]);

                rowResult.columnResults.Add(compareColumnResult);
            }

            return rowResult;
        }

        private static CompareRowResult ObjectComparerInternalRow<T>(
            IEnumerable<ColumnToActionContainer<IComparerColumnAction>> columnActions,
            T data)
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

        private static Table VerticalToHorizonal(Table table)
        {
            // | Field | Value |
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
