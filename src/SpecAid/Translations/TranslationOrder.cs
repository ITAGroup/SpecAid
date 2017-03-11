namespace SpecAid.Translations
{
    public enum TranslationOrder
    {
        // Ultimate override built into the Actions
        Ignore = 0,            // [ignore]

        // Ultimate override for string
        QuotedString = 10,     // "Hello"

        Swapped = 15,          // {#Employee.Id}

        // Single word replacements
        Null = 20,             // null
        Today = 30,            // [today]
        Tomorrow = 40,         // [tomorrow]
        Yesterday = 50,        // [yesterday]

        // Textual Triggers
        Tag = 60,              // #Entry
        DeepLink = 70,         // #Entry.Item
        Array = 75,            // [this,that]
        List = 80,             // [this,that]
        Date = 90,             // 2014-06-25

        // Types
        Boolean = 100,         // true
        DateTime = 110,        // 2014-06-25 08:21 AM
        DateTimeOffset = 111,  // 2014-06-25 08:21 AM -06:00
        Guid = 120,            // 7e764906-8689-4cc6-b290-461038681c7a
        Enum = 130,            // Blue
        NullableEnum = 135,    // Blue
        NullableGeneric = 140, // true

        Linq = 980,            // do(5 + 5)

        Missing = 990
    }
}
