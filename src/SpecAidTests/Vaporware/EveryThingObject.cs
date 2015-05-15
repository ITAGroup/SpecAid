using System;
using System.Collections;
using System.Collections.Generic;

namespace SpecAidTests.Vaporware
{
    public class EveryThingObject
    {
        public Guid Id { get; private set; }

        public Guid AGuid { get; set; }
        public Guid? ANullableGuid { get; set; }
        public int AnInt { get; set; }
        public string AString { get; set; }
        public IList PlainList { get; set; }
        public IList<string> ListStrings { get; set; }
        public string[] ArrayStrings { get; set; }
        public IEnumerable<string> SomeStrings { get; set; }
        public EveryThingObject InnerEveryThingObject { get; set; }

        public EveryThingObject()
        {
            Id = Guid.NewGuid();
        }

        public string MyErrorMessage
        {
            get
            {
                return "Everything Object with Id " + Id + " message.";
            }
        }
    }
}