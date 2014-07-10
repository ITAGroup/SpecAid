using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SpecAid.Base;
using TechTalk.SpecFlow;

namespace SpecAid.ColumnActions
{
    public class ColumnActionFactory
    {

        /// <summary>
        /// Gets the appropriate action for the given interface and column name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static T GetAction<T>(Type type, string columnName) where T : IColumnAction
        {
            var actions = getActions<T>(type, columnName);

            foreach (var action in actions)
            {
                if (action.UseWhen())
                {
                    return action;
                }
            }

            // With a Unknown Action... We will NEVER get here.  Unless the Unknown Action is turned off.

            throw new ArgumentException("Unable to determine what to do with column:" + columnName);
        }
        
        /// <summary>
        /// Do all of the types that are of match action and given interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        /// <remarks>May want to change this to be lazy loaded so i'm not creating this all of the time</remarks>
        private static IEnumerable<T> getActions<T>(Type type, string columnName) where T : IColumnAction
        {
            var specAidAssembly = Assembly.GetExecutingAssembly();

            var specAidTypes = specAidAssembly.GetTypes()
                .Where(typeof(T).IsAssignableFrom)
                .Where(typeof(ColumnAction).IsAssignableFrom).ToList();

            var specAidActions =
                specAidTypes.Select(action => (T) Activator.CreateInstance(action, type, columnName)).OrderBy(
                    t => t.considerOrder);


            var testAssembly = Assembly.GetExecutingAssembly();

            var testTypes = testAssembly.GetTypes()
                .Where(typeof(T).IsAssignableFrom)
                .Where(typeof(ColumnAction).IsAssignableFrom).ToList();

            var testActions =
                testTypes.Select(action => (T)Activator.CreateInstance(action, type, columnName)).OrderBy(
                    t => t.considerOrder);

            return testActions.Union(specAidActions);
        }

        /// <summary>
        /// Method to match columns in a table to properties in a object
        /// </summary>
        public static IEnumerable<ColumnToActionContainer<T>> GetActionsFromColumns<T>(Table table, Type target)
            where T : IColumnAction
        {
            return GetActionsFromColumns<T>(table, target, null);
        }

        /// <summary>
        /// Method to match columns in a table to properties in a object
        /// </summary>
        public static IEnumerable<ColumnToActionContainer<T>> GetActionsFromColumns<T>(
            Table table, Type target, IEnumerable<ColumnToActionContainer<T>> overrides )
            where T : IColumnAction
        {
            //setup my return object
            var columnToActions = new List<ColumnToActionContainer<T>>();

            if (overrides != null)
            {
                foreach (var aOverride in overrides)
                {
                    if (aOverride.ColumnIndex == null)
                    {
                        // convert name to index
                        for (int i = 0; i < table.Header.Count; i++)
                        {
                            if (table.Header.ElementAt(i) == aOverride.ColumnName)
                            {
                                aOverride.ColumnIndex = i;
                                columnToActions.Add(aOverride);
                            }
                        }
                        continue;
                    }

                    if (aOverride.ColumnName == null)
                    {
                        aOverride.ColumnName = table.Header.ElementAt(aOverride.ColumnIndex.Value);
                        columnToActions.Add(aOverride);
                        continue;
                    }

                    columnToActions.Add(aOverride);
                    continue;
                }
            }

            //run through each column and set the matching prop
            for (var tableColumnIndex = 0; tableColumnIndex < table.Header.Count(); tableColumnIndex++)
            {
                if (columnToActions.Any(x => x.ColumnIndex == tableColumnIndex))
                    continue;

                var HeaderItem = table.Header.ElementAt(tableColumnIndex);

                var columnAction = new ColumnToActionContainer<T>()
                {
                    ColumnIndex = tableColumnIndex,
                    ColumnName = HeaderItem,
                    MatchAction = ColumnActionFactory.GetAction<T>(target, HeaderItem)
                };
                columnToActions.Add(columnAction);
            }

            //Print needs these in the same order as the columns
            var sortedActions = columnToActions.OrderBy(x => x.ColumnIndex);

            //return the mappings of the successful columns
            return sortedActions;
        }

    }
}
