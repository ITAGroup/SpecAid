namespace SpecAid.Base
{
    public class ColumnToActionContainer<T>
    {
        public string ColumnName { get; set; }
        public int? ColumnIndex { get; set; }
        public T MatchAction { get; set; }

        public ColumnToActionContainer(){}

        public ColumnToActionContainer(string columnName, T matchAction)
        {
            ColumnName = columnName;
            MatchAction = matchAction;
        }

        public ColumnToActionContainer(int columnIndex, T matchAction)
        {
            ColumnIndex = columnIndex;
            MatchAction = matchAction;
        }

    }
}
