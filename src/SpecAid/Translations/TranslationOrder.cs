using System;

namespace SpecAid.Translations
{
    public enum TranslationOrder
    {
        // Ultimate override built into the Actions
        Ignore = 0,            // [ignore]

        // Ultimate override for string
        String = 10,           // "Hello"      Quoted String

        // Single word replacements
        Null = 20,             // null
        Today = 30,            // [today]
        Tomorrow = 40,         // [tomorrow]
        Yesterday = 50,        // [yesterday]

        // Textual Triggers
        Tag = 60,              // #Entry       Tag
        DeepLink = 70,         // #Entry.Item
        List = 80,             // [this,that]
        Date = 90,             // 2014-06-25

        // Types
        Boolean = 100,         // true
        DateTime = 110,        // 2014-06-25 08:21 AM
        Guid = 120,            // 7e764906-8689-4cc6-b290-461038681c7a
        Enum = 130,            // Blue
        NullableGeneric = 140, // true

        Linq = 980,            // {5 + 5}
        Missing = 990
    }
}
