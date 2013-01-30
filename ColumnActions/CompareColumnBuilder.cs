using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecAid.Base;

namespace SpecAid.ColumnActions
{
    public class CompareColumnBuilder<T>
    {
        private List<ColumnToActionContainer<IComparerColumnAction>> columnOverrides = new List<ColumnToActionContainer<IComparerColumnAction>>();

        public CompareColumnBuilder<T> AddIgnore(string columnName)
        {
            var aOverride = new ColumnToActionContainer<IComparerColumnAction>();
            aOverride.ColumnName = columnName;
            aOverride.MatchAction = new IgnoreAction(null, columnName);
            columnOverrides.Add(aOverride);
            return this;
        }

        public CompareColumnBuilder<T> AddSymbolic(string columnName, string symbolic)
        {
            var action = ColumnActionFactory.GetAction<IComparerColumnAction>(typeof(T), symbolic);

            var aOverride = new ColumnToActionContainer<IComparerColumnAction>();
            aOverride.ColumnName = columnName;
            aOverride.MatchAction = action;
            columnOverrides.Add(aOverride);

            return this;
        }

        public List<ColumnToActionContainer<IComparerColumnAction>> Out
        {
            get { return columnOverrides; }
        }
    }
}
