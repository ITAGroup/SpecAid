using System.Collections.Generic;

namespace SpecAidTests.Vaporware
{
    public class ComplexIndexerObject
    {
        private readonly Dictionary<int,string> _ints = new Dictionary<int,string>();
        private readonly Dictionary<string, string> _strings = new Dictionary<string, string>();

        public string this[int i]
        {
            get { return _ints[i]; }
            set { _ints[i] = value; }
        }

        public string this[string i]
        {
            get { return _strings[i]; }
            set { _strings[i] = value; }
        }

        public int CountOfIntLookups
        {
            get { return _ints.Count; }
        }

        public int CountOfStringLookups
        {
            get { return _ints.Count; }
        }
    }
}