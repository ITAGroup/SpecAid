namespace SpecAid.ColumnActions
{
    public enum ActionOrder
    {
        // Ultimate override
        Ignore = 0,

        // Textual Triggers
        Tag = 10,          // #Hello
        ThisCompare = 20,  // This
        DeepCompare = 30,  // #Hello.Kitty
        DeepSet = 40,      // #Hello.Kitty
        // Iterator        // #Hello.Cats[0]
        // Linq            // {This.Cats.First()}

        // Specific Type Handlers
        ListCompare = 110,

        // Generic Type Handlers
        Set = 1110,
        Compare = 1120,

        // Unknown
        Unknown = 9999
    }
}
