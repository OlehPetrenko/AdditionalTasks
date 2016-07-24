using System.Collections.Generic;

namespace Task5
{
    internal class Collection<TKey, TValue>
    {
        private readonly List<TValue> _data = new List<TValue>();
        private readonly Dictionary<TKey, int> _entries = new Dictionary<TKey, int>();


        public void Add(TKey key, TValue value)
        {
            _entries.Add(key, _data.Count);

            _data.Add(value);
        }

        #region Indexers

        public TValue this[int index]
        {
            get { return _data[index]; }
        }

        public TValue this[TKey key]
        {
            get { return _data[_entries[key]]; }
        }

        #endregion
    }
}
