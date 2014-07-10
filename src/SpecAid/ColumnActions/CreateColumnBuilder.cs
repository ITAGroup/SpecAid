using System.Collections.Generic;
using SpecAid.Base;

namespace SpecAid.ColumnActions
{
    public class CreateColumnBuilder<T>
    {
        private readonly List<ColumnToActionContainer<ICreatorColumnAction>> _columnOverrides = new List<ColumnToActionContainer<ICreatorColumnAction>>();

        public CreateColumnBuilder<T> AddIgnore(string columnName)
        {
            var aOverride = new ColumnToActionContainer<ICreatorColumnAction>();
            aOverride.ColumnName = columnName;
            aOverride.MatchAction = new IgnoreAction(null, columnName);
            _columnOverrides.Add(aOverride);
            return this;
        }

        public CreateColumnBuilder<T> AddSymbolic(string columnName, string symbolic)
        {
            var action = ColumnActionFactory.GetAction<ICreatorColumnAction>(typeof(T), symbolic);

            var aOverride = new ColumnToActionContainer<ICreatorColumnAction>();
            aOverride.ColumnName = columnName;
            aOverride.MatchAction = action;
            _columnOverrides.Add(aOverride);

            return this;
        }

        public List<ColumnToActionContainer<ICreatorColumnAction>> Out
        {
            get { return _columnOverrides; }
        }
    }
}
