using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecAid.Base
{
    public class CompareTableResult
    {
        // For Row Count and Table Columns Name
        private Table _table;

        // Holds a list of compares... Used during Best Matching (finalization)
        private CompareRowResult[,] _tableRowToDataCompares;

        // Finals... Perfect Matches, Non-Perfect and No-Match
        private CompareRowFinalResult[] _tableRowToDataCompareRowFinals;
        private CompareRowFinalResult[] _dataToTableRowCompareRowFinals;

        // How big is it?
        private int _tableRowsCount;
        private int _dataItemsCount;

        // Final Messages
        private readonly List<string> _messages = new List<string>();

        public void InitCompare(Table table, int dataItemsCount)
        {
            _table = table;

            _tableRowsCount = table.RowCount;
            _dataItemsCount = dataItemsCount;

            // We add one to Allow for the Null or (no Match Condition)
            _tableRowToDataCompares = new CompareRowResult[_tableRowsCount + 1, _dataItemsCount + 1];

            // Just in case we index to a blank record...  + 1.
            _tableRowToDataCompareRowFinals = new CompareRowFinalResult[_tableRowsCount];
            _dataToTableRowCompareRowFinals = new CompareRowFinalResult[_dataItemsCount];
        }

        // Used by TableAid to Add a new Result.
        public void AddRowResult(
            int tableRowIndex,
            int dataItemIndex,
            CompareRowResult rowResult,
            bool isMatch)
        {
            // These are for No Matches...
            // We left a little space in the table to make these...
            if (tableRowIndex == int.MaxValue)
                tableRowIndex = _tableRowsCount;

            if (dataItemIndex == int.MaxValue)
                dataItemIndex = _dataItemsCount;

            if (isMatch == true)
            {
                AddFinalMatch(tableRowIndex, dataItemIndex, rowResult, MatchQuality.PerfectMatch);
            }
            else
            {
                _tableRowToDataCompares[tableRowIndex, dataItemIndex] = rowResult;
            }
        }

        public bool DoesDataHaveMatch(int dataItemIndex)
        {
            if (_dataToTableRowCompareRowFinals[dataItemIndex] != null)
                return true;

            return false;
        }

        public void FinalAnalyst()
        {
            CompleteFinal();

            // Order And Other Exceptions

            FinalMessages();
        }

        public string PrintMeSpecflowStyle()
        {
            var output = new List<List<string>>();

            output.Add(TableHeaderToList());

            // Actual for Print
            CompareRowResultToOutput
            (
                output,
                'E', 'A',
                _tableRowToDataCompareRowFinals,
                ExpectedPrintToOutput
            );

            output.Add(TableHeaderToList());

            CompareRowResultToOutput
            (
                output,
                'A', 'E',
                _dataToTableRowCompareRowFinals,
                ActualPrintToOutput
            );

            var outputSb = new StringBuilder();

            // Format the List
            ActualAndExpectedToSpecflowPipeOutput(output, outputSb);

            // Messages
            MessagesToStringBuilder(outputSb);

            return outputSb.ToString();
        }

        private void CompleteFinal()
        {
            // Build Final
            var killLoop = false;

            while (!killLoop)
            {
                killLoop = true;

                var bestFinalMisMatchDataIndex = 0;
                var bestFinalMisMatchTableRowIndex = 0;
                CompareRowResult bestFinalMisMatch = null;

                for (int tableRowIndex = 0; tableRowIndex < _tableRowsCount; tableRowIndex++)
                {
                    // It a Final Match is already set, then skip.
                    if (_tableRowToDataCompareRowFinals[tableRowIndex] != null)
                        continue;

                    // No Match... find one.
                    var bestDataIndex = FindBestMatch(
                        tableRowIndex, 
                        _dataItemsCount, 
                        TableRowToDataRetrieval);

                    var bestDataFinal = _tableRowToDataCompares[tableRowIndex, bestDataIndex];

                    // Missing Record (add and continue)
                    if (bestDataIndex == _dataItemsCount)
                    {
                        AddFinalMatch(tableRowIndex, bestDataIndex, bestDataFinal, MatchQuality.None);
                        killLoop = false;
                        continue;
                    }

                    var bestTableRowIndexForData = FindBestMatch(
                        bestDataIndex, 
                        _tableRowsCount, 
                        DataToTableRowRetrieval);

                    // Verify the Data believe that the it is also the closes Match
                    if (tableRowIndex != bestTableRowIndexForData)
                    {
                        continue;
                    }

                    // At this point we have a Match...
                    // And we will reloop
                    // But really is this match combo better than the last ???
                    if (bestFinalMisMatch == null || bestFinalMisMatch.totalErrors < bestDataFinal.totalErrors)
                    {
                        bestFinalMisMatchDataIndex = bestDataIndex;
                        bestFinalMisMatchTableRowIndex = tableRowIndex;
                        bestFinalMisMatch = bestDataFinal;
                        killLoop = false;
                        continue;
                    }
                }

                // if there is a Match Add it.
                if (bestFinalMisMatch != null)
                {
                    AddFinalMatch(
                        bestFinalMisMatchTableRowIndex, 
                        bestFinalMisMatchDataIndex, 
                        bestFinalMisMatch, 
                        MatchQuality.Partial);
                }
            }

            for (int dataItemIndex = 0; dataItemIndex < _dataItemsCount; dataItemIndex++)
            {
                if (_dataToTableRowCompareRowFinals[dataItemIndex] != null)
                    continue;

                var MissingRow = _tableRowToDataCompares[_tableRowsCount, dataItemIndex];

                AddFinalMatch(_tableRowsCount, dataItemIndex, MissingRow, MatchQuality.None);
            }
        }

        public void TheAssert()
        {
            if (_messages.Count == 0)
            {
                Assert.AreEqual(true,true);
                return;
            }

            Assert.Fail(_messages[0]);
        }

        private void FinalMessages()
        {
            for (int tableRowIndex = 0; tableRowIndex < _tableRowsCount; tableRowIndex++)
            {
                var compare = _tableRowToDataCompareRowFinals[tableRowIndex];

                if (compare.matchQuality == MatchQuality.None)
                {
                    _messages.Add("Could Not Match Row E" + (tableRowIndex + 1) + ": Not Enough Data.");
                    continue;
                }

                var errorCounter = 0;

                foreach (var column in compare.compareRowResult.columnResults.Where(c => c.IsError))
                {
                    errorCounter++;
                    if (errorCounter > 2)
                        break;
                    if (compare.matchQuality == MatchQuality.Partial)
                    {
                        _messages.Add(
                            "Non-Match on Row E" + (tableRowIndex + 1) + 
                            ": Best Guess A" + (compare.index + 1) +
                            ": " + column.ErrorMessage);
                    }
                    else
                    {
                        _messages.Add(
                            "Error on Row E" + (tableRowIndex + 1) + 
                            ": " + column.ErrorMessage);
                    }
                }
            }

            for (int dataIndex = 0; dataIndex < _dataItemsCount; dataIndex++)
            {
                var compare = _dataToTableRowCompareRowFinals[dataIndex];

                if (compare.matchQuality == MatchQuality.None)
                {
                    _messages.Add(
                        "Could Not Match Row A" + (dataIndex + 1) + 
                        ": Not Enough Table Rows.");
                    continue;
                }

            }
        }

        private void AddFinalMatch(
            int tableRowIndex, 
            int dataIndex, 
            CompareRowResult rowResult, 
            MatchQuality matchQuality)
        {
            // Missing TableRows are not added to final
            if (tableRowIndex != _tableRowsCount)
            {
                // A Match calls us to action.
                // We need to remove previous compares.
                // So, that when we finalize... Matches won't get confused with other Match Data
                for (int dataForIndex = 0; dataForIndex < _dataItemsCount; dataForIndex++)
                {
                    _tableRowToDataCompares[tableRowIndex, dataForIndex] = null;
                }

                var tableRowCompareMatchResult = new CompareRowFinalResult();
                tableRowCompareMatchResult.compareRowResult = rowResult;
                tableRowCompareMatchResult.matchQuality = matchQuality;
                tableRowCompareMatchResult.index = dataIndex;
                _tableRowToDataCompareRowFinals[tableRowIndex] = tableRowCompareMatchResult;
            }

            // Missing Datas are not added to final
            if (dataIndex != _dataItemsCount)
            {
                for (int tableRowForIndex = 0; tableRowForIndex < _tableRowsCount; tableRowForIndex++)
                {
                    _tableRowToDataCompares[tableRowForIndex, dataIndex] = null;
                }

                var dataCompareMatchResult = new CompareRowFinalResult();
                dataCompareMatchResult.compareRowResult = rowResult;
                dataCompareMatchResult.matchQuality = matchQuality;
                dataCompareMatchResult.index = tableRowIndex;
                _dataToTableRowCompareRowFinals[dataIndex] = dataCompareMatchResult;
            }
        }

        private void ActualAndExpectedToSpecflowPipeOutput(
            List<List<string>> output, 
            StringBuilder outputToStringBuilder)
        {
            var columnCount = _table.Header.Count + 3;
            var totalWidthOfColumns = new int[columnCount];

            // Get max width of each column
            foreach (var outLine in output)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    if (totalWidthOfColumns[i] < outLine[i].Length)
                        totalWidthOfColumns[i] = outLine[i].Length;
                }
            }

            outputToStringBuilder.AppendLine("Expected:");

            var outLineCount = -1;  // Zero Relative.. Add on entry

            foreach (var outLine in output)
            {
                outLineCount++;

                // We interrupt this output for a special announcement.
                if (outLineCount == _tableRowsCount + 1) // Add one for the Header
                {
                    outputToStringBuilder.AppendLine("Actual:");
                }

                outputToStringBuilder.Append("\t");
                outputToStringBuilder.Append("| ");
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    outputToStringBuilder.Append(
                        outLine[columnIndex].PadRight(totalWidthOfColumns[columnIndex]));

                    outputToStringBuilder.Append(" | ");
                }
                outputToStringBuilder.AppendLine();
            }
        }

        public void MessagesToStringBuilder(StringBuilder outputToStringBuilder)
        {
            outputToStringBuilder.AppendLine("Messages:");

            if (_messages.Count == 0)
            {
                outputToStringBuilder.AppendLine("\tnone");
            }

            foreach (var message in _messages)
            {
                outputToStringBuilder.Append("\t");
                outputToStringBuilder.AppendLine(message);
            }

        }

        private static void CompareRowResultToOutput
            (
                List<List<string>> output,
                char selfIdentifier,
                char matchIdentifier,
                CompareRowFinalResult[] compareRowFinals,
                Action<List<CompareColumnResult>, List<string>> columnPrinter
            )
        {
            for (int firstIndex = 0; firstIndex < compareRowFinals.Count(); firstIndex++)
            {
                var compareRowFinal = compareRowFinals[firstIndex];

                // # Identifier Column
                var outputLine = new List<string>();
                outputLine.Add(selfIdentifier + (firstIndex + 1).ToString());

                // Match Column
                if (compareRowFinal.matchQuality == MatchQuality.PerfectMatch)
                {
                    outputLine.Add(matchIdentifier + (compareRowFinal.index + 1).ToString());
                }
                else if (compareRowFinal.matchQuality == MatchQuality.Partial)
                {
                    outputLine.Add("? " + matchIdentifier + (compareRowFinal.index + 1).ToString());
                }
                else
                {
                    outputLine.Add(" ");
                }

                // Error Column
                if (compareRowFinal.matchQuality == MatchQuality.None)
                {
                    outputLine.Add("No Match");
                }
                else if (compareRowFinal.matchQuality == MatchQuality.PerfectMatch)
                {
                    var totalErrors = compareRowFinal.compareRowResult.totalErrors;
                    if (totalErrors != 0)
                    {
                        outputLine.Add(totalErrors.ToString() + " Columns");
                    }
                    else
                    {
                        outputLine.Add("perfect");
                    }
                }
                else
                {
                    // Partial
                    var totalErrors = compareRowFinal.compareRowResult.totalErrors;
                    if (totalErrors != 0)
                    {
                        outputLine.Add("Best " + totalErrors + " Columns");
                    }                    
                }

                columnPrinter(compareRowFinal.compareRowResult.columnResults, outputLine);

                output.Add(outputLine);
            }
        }

        // Used in Best Match...
        private CompareRowResult TableRowToDataRetrieval(int tableRowIndex, int dataIndex)
        {
            return _tableRowToDataCompares[tableRowIndex, dataIndex];
        }

        // Used in Best Match...
        private CompareRowResult DataToTableRowRetrieval(int dataIndex, int tableRowIndex)
        {
            return _tableRowToDataCompares[tableRowIndex, dataIndex];
        }

        // Used in CompareRowResultToOutput
        private static void ActualPrintToOutput(
            List<CompareColumnResult> columnResults, 
            List<string> outputLine)
        {
            foreach (var compareColumnResult in columnResults)
            {
                // Columns
                if (compareColumnResult.IsError)
                    outputLine.Add(compareColumnResult.ActualPrint + " (!)");
                else
                    outputLine.Add(compareColumnResult.ActualPrint);
            }
        }

        // Used in CompareRowResultToOutput
        private static void ExpectedPrintToOutput(
            List<CompareColumnResult> columnResults, 
            List<string> outputLine)
        {
            foreach (var compareColumnResult in columnResults)
            {
                // Columns
                if (compareColumnResult.IsError)
                    outputLine.Add(compareColumnResult.ExpectedPrint + " (!)");
                else
                    outputLine.Add(compareColumnResult.ExpectedPrint);
            }
        }

        private static int FindBestMatch(
            int firstIndex, 
            int secondCount, 
            Func<int, int, CompareRowResult> compares)
        {
            CompareRowResult best = null;
            int bestIndex = 0;

            // secondCount + 1 allows us to get to the Missing Record Section
            for (int secondIndex = 0; secondIndex < secondCount; secondIndex++)
            {
                var compare = compares(firstIndex, secondIndex);
                if (compare == null)
                    continue;
                if (best == null)
                {
                    best = compare;
                    bestIndex = secondIndex;
                    continue;
                }
                if (compare.totalErrors < best.totalErrors)
                {
                    best = compare;
                    bestIndex = secondIndex;
                    continue;
                }
            }

            // no matching records return matching
            if (best == null)
                return secondCount;

            return bestIndex;
        }

        private List<string> TableHeaderToList()
        {
            var output = new List<string>();
            output.Add("");
            output.Add("Match");
            output.Add("Error");

            foreach (var columnHeader in _table.Header)
            {
                output.Add(columnHeader);
            }

            return output;
        }
    }

    public enum MatchQuality
    {
        PerfectMatch,
        Partial,
        None
    }

    public class CompareRowFinalResult
    {
        public MatchQuality matchQuality;
        public CompareRowResult compareRowResult;
        public int? index;
    }
}
