namespace SpecAid.Base
{
    public interface IColumnAction
    {
        bool UseWhen();
        int considerOrder { get; }
    }
}
