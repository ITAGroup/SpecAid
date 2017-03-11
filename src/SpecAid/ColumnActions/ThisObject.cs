namespace SpecAid.ColumnActions
{
    // Convert a Object to a Property
    internal class ThisObject
    {
        public ThisObject(object obj)
        {
            This = obj;
        }

        public object This { get; set; }
    }
}