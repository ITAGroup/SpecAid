namespace SpecAid.Base
{
    public class ColumnNameToActionContainer<T>
    {
        public string TableColumnName { get; set; }
        public T MatchAction { get; set; }
    }
}
