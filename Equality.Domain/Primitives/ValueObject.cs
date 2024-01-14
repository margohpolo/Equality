using System.Reflection;

namespace Equality.Domain.Primitives
{
    //Generic version of Milan's implementation, with Reflection.
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
    {
        //***Note: For demo purposes only. Not a good idea to expose too much PII in logs.
        public override string ToString()
            => GetAtomicValues().ToString()!;

        public bool Equals(ValueObject<T>? t)
            => (t is not null || this.GetType() != t!.GetType())
                && t is ValueObject<T> other 
                && ValuesAreEqual(other);

        public static bool operator ==(ValueObject<T>? lhs, T? rhs)
            => lhs.Equals(rhs);

        public static bool operator !=(ValueObject<T>? lhs, T? rhs)
            => !lhs.Equals(rhs);

        public sealed override bool Equals(object? obj)
            => obj is ValueObject<T> other 
                && ValuesAreEqual(other);

        public sealed override int GetHashCode()
            => GetAtomicValues()
                .Aggregate(default(int), HashCode.Combine);

        ////From Microsoft docs
        //protected static bool EqualOperator(T? lhs, T? rhs)
        //{
        //    if (lhs is null ^ rhs is null) return false;

        //    return ReferenceEquals(lhs, rhs) || lhs.Equals(rhs);
        //}

        private bool ValuesAreEqual(ValueObject<T> other)
            => GetAtomicValues()
                .SequenceEqual(other.GetAtomicValues());

        private IEnumerable<object?> GetAtomicValues()
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                yield return property.GetValue(this)!;
            }
        }
    }
}
