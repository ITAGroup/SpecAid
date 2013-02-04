namespace SpecAid.Base
{
    public interface IComparerColumnAction : IColumnAction
    {
        CompareColumnResult GoGoCompareColumnAction(object obj, string tableValue);
        CompareColumnResult GoGoCompareColumnAction(object obj);
        CompareColumnResult GoGoCompareColumnAction(string tableValue);
    }
}
