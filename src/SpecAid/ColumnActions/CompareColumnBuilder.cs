using System.Collections.Generic;
using SpecAid.Base;

namespace SpecAid.ColumnActions
{
    public class CompareColumnBuilder<T>
    {
        private readonly List<ColumnToActionContainer<IComparerColumnAction>> _columnOverrides = new List<ColumnToActionContainer<IComparerColumnAction>>();

        public CompareColumnBuilder<T> AddIgnore(string columnName)
        {
            var aOverride = new ColumnToActionContainer<IComparerColumnAction>();
            aOverride.ColumnName = columnName;
            aOverride.MatchAction = new IgnoreAction(null, columnName);
            _columnOverrides.Add(aOverride);
            return this;
        }

        public CompareColumnBuilder<T> AddSymbolic(string columnName, string symbolic)
        {
            var action = ColumnActionFactory.GetAction<IComparerColumnAction>(typeof(T), symbolic);

            var aOverride = new ColumnToActionContainer<IComparerColumnAction>();
            aOverride.ColumnName = columnName;
            aOverride.MatchAction = action;
            _columnOverrides.Add(aOverride);

            return this;
        }

        public List<ColumnToActionContainer<IComparerColumnAction>> Out
        {
            get { return _columnOverrides; }
        }
    }
}
