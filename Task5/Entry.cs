using System;

namespace Task5
{
    public class Entry
    {
        private readonly char[] _key;

        public int IntValue1;
        public int IntValue2;

        private short _flags;


        public Entry(string key)
        {
            _flags = 0;

            _key = new char[32];

            _key = key.ToCharArray();
        }

        public string GetKey()
        {
            return new string(_key);
        }

        #region Flags

        public void SetFlag(short numberFlag, bool valueFlag)
        {
            if (numberFlag < 0 || numberFlag >= 16)
            {
                throw new ArgumentException("Number of flag isn't correct");
            }

            if (valueFlag)
            {
                _flags = (Int16) (_flags | (1 << numberFlag));
            }
            else
            {
                _flags = (Int16) (_flags & ~(1 << numberFlag));
            }
        }

        public bool GetFlag(short numberFlag)
        {
            if (numberFlag < 0 || numberFlag >= 16)
            {
                throw new ArgumentException("Number of flag isn't correct");
            }

            return (_flags & (1 << numberFlag)) != 0;
        }

        #endregion
    }
}
