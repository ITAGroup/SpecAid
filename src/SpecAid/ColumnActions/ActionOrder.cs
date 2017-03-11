namespace SpecAid.ColumnActions
{
    public enum ActionOrder
    {
        // object for examples:
        //  "person" : {
        //    "firstName" : "John",
        //    "address" : {
        //      "city" : "anywhere"
        //    },
        //    "roles" : [
        //      {"role" : "admin"}
        //    ],
        //    "[]" : [
        //      {"key" : "aka","value" : "Jake"}
        //    ]
        //  }

        // Ultimate override
        Ignore = 0,             // !Key

        // Textual Triggers
        Tag = 10,               // Tag It
        ThisCompare = 20,       // This

        // "." Triggers
        DeepCompare = 30,       // address.city
        DeepSet = 40,           // address.city

        // Specific Type Handlers
        ListCompare = 110,      // roles

        // Generic Type Handlers Based on Property
        Set = 1110,             // firstName
        Compare = 1120,         // firstName

        // Generic Type Handlers Based on Indexers
        IndexerSet = 2110,      // aka
        IndexerCompare = 2120,  // aka

        // Unknown
        Unknown = 9999
    }
}
