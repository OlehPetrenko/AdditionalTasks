using System;

namespace Task1
{
    public struct NullType<T> where T : struct
    {
        private readonly bool _hasValue;
        private readonly T _value;


        public NullType(T value)
        {
            _value = value;
            _hasValue = true;
        }

        public bool HasValue
        {
            get { return _hasValue; }
        }

        public T Value
        {
            get
            {
                if (!_hasValue)
                {
                    throw new InvalidOperationException("NullType object must have a value");
                }
                return _value;
            }
        }

        public static implicit operator NullType<T>(T value)
        {
            return new NullType<T>(value);
        }

        public static explicit operator T(NullType<T> value)
        {
            return value.Value;
        }

        public override bool Equals(object obj)
        {
            if (!HasValue) return (obj == null);

            return obj != null && Value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return !HasValue ? 0 : _value.GetHashCode();
        }
        
        #region Arithmetic operators

        public static NullType<T> operator +(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value + obj2.Value;
        }

        public static NullType<T> operator -(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value - obj2.Value;
        }

        public static NullType<T> operator *(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value*obj2.Value;
        }

        public static NullType<T> operator /(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value/obj2.Value;
        }

        /*public static NullType<T> operator ++(NullType<T> obj1)
        {
            return (dynamic)obj1.Value + 1;
        }

        public static NullType<T> operator --(NullType<T> obj1)
        {
            return (dynamic)obj1.Value - 1;
        }*/

        #endregion

        #region Bitwise operators

        public static NullType<T> operator &(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic)obj1.Value & obj2.Value;
        }

        public static NullType<T> operator |(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic)obj1.Value | obj2.Value;
        }

        public static NullType<T> operator ^(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic)obj1.Value ^ obj2.Value;
        }

        public static NullType<T> operator >>(NullType<T> obj1, int countBits)
        {
            return (dynamic) obj1.Value >> countBits;
        }

        public static NullType<T> operator <<(NullType<T> obj1, int countBits)
        {
            return (dynamic)obj1.Value << countBits;
        }

        public static NullType<T> operator ~(NullType<T> obj1)
        {
            return ~(dynamic)obj1.Value;
        }

        #endregion

        #region Comparison operators

        public static bool operator >(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value > obj2.Value;
        }

        public static bool operator <(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value < obj2.Value;
        }

        public static bool operator ==(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value == obj2.Value;
        }

        public static bool operator !=(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value != obj2.Value;
        }

        public static bool operator >=(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value >= obj2.Value;
        }

        public static bool operator <=(NullType<T> obj1, NullType<T> obj2)
        {
            return (dynamic) obj1.Value <= obj2.Value;
        }

        #endregion

        #region True and false operators

        public static bool operator true(NullType<T> obj1)
        {
            return obj1._hasValue;
        }

        public static bool operator false(NullType<T> obj1)
        {
            return !obj1._hasValue;
        }

        #endregion
    }
}
