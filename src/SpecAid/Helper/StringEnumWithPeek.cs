using System.Collections;
using System.Collections.Generic;

namespace SpecAid.Helper
{
    /// <summary>
    /// Also, returns null instead of index out of range error.
    /// </summary>
    public class StringEnumWithPeek : IEnumerator<char?>
    {
        private int _index = -1;
        private readonly string _item;

        public StringEnumWithPeek(string item)
        {
            _item = item;
        }

        private char? SafeGet(int index)
        {
            if (index >= _item.Length)
                return null;
            return _item[index];
        }

        public bool MoveNext()
        {
            _index++;
            return SafeGet(_index) != null;
        }

        public void Reset()
        {
            _index = -1;
        }

        public char? Current
        {
            get
            {
                return SafeGet(_index);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return SafeGet(_index);
            }
        }

        public char? PeekNext()
        {
            return PeekNext(1);
        }

        public char? PeekNext(int ahead)
        {
            return SafeGet(_index + ahead);
        }

        public void Dispose()
        {
            // Nothing to kill
        }
    }
}