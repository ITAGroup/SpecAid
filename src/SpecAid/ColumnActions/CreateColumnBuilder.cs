using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecAid.Base;

namespace SpecAid.ColumnActions
{
    public class CreateColumnBuilder<T>
    {
        private List<ColumnToActionContainer<ICreatorColumnAction>> columnOverrides = new List<ColumnToActionContainer<ICreatorColumnAction>>();

        public CreateColumnBuilder<T> AddIgnore(string columnName)
        {
            var aOverride = new ColumnToActionContainer<ICreatorColumnAction>();
            aOverride.ColumnName = columnName;
            aOverride.MatchAction = new IgnoreAction(null, columnName);
            columnOverrides.Add(aOverride);
            return this;
        }

        public CreateColumnBuilder<T> AddSymbolic(string columnName, string symbolic)
        {
            var action = ColumnActionFactory.GetAction<ICreatorColumnAction>(typeof(T), symbolic);

            var aOverride = new ColumnToActionContainer<ICreatorColumnAction>();
            aOverride.ColumnName = columnName;
            aOverride.MatchAction = action;
            columnOverrides.Add(aOverride);

            return this;
        }

        public List<ColumnToActionContainer<ICreatorColumnAction>> Out
        {
            get { return columnOverrides; }
        }
    }
}
