using System;
using System.Collections;

namespace Task2
{
    class Sequence
    {
        private readonly BitArray _data;

        public int Count
        {
            get { return _data.Count; }
        }


        public Sequence(int length)
        {
            _data = new BitArray(length);
        }

        public void FillRandom()
        {
            var rnd = new Random((int)DateTime.Now.Ticks);

            for (var i = 0; i < _data.Count; i++)
            {
                _data.Set(i, Convert.ToBoolean(rnd.Next(0, 2)));
            }
        }

        #region GetSet

        public void SetNumberToSequence(int index, int value)
        {
            _data.Set(index, Convert.ToBoolean(value));
        }

        public Byte GetNumberFromSequence(int index)
        {
            return Convert.ToByte(_data.Get(index));
        }

        #endregion

        #region Functions for count sequence

        private int CountSubsequence(int number)
        {
            return number * (number - 1) / 2;
        }

        public long CountSequence()
        {
            var result = 0;

            var separationLength = 0;
            var subsequenceLength = 0;

            for (var i = 0; i < _data.Count; i++)
            {
                if (separationLength == 1 && _data[i])
                {
                    result += CountSubsequence(subsequenceLength);

                    while (i < _data.Count-1 && _data[++i])
                    {

                    }

                    if (i == _data.Count - 1)
                    {
                        return result;
                    }

                    subsequenceLength = 1;
                }

                separationLength = 0;

                if (_data[i])
                {
                    separationLength++;
                }

                subsequenceLength++;   
            }

            return result + CountSubsequence(subsequenceLength);
        }

        #endregion
    }
}
