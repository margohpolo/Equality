using Equality.Domain.Primitives;
using System.Numerics;

namespace Equality.Domain.ValueObjects
{
    public sealed class Money(decimal value) 
        : ValueObject<Money>
    {
        public decimal Value { get; } = value;

        public override string ToString()
        {
            return '$' + Value.ToString("#,###.00");
        }

        #region Operators
        public static Money operator +(Money a, Money b)
            => new(a.Value + b.Value);

        public static Money operator -(Money a, Money b)
            => new(a.Value - b.Value);

        //Rounding would be subject to business rules
        public static Money operator *(Money money, decimal fraction)
            => new(Math.Round(money.Value * fraction, 2));

        public static bool operator ==(Money a, Money b)
            => a.Value == b.Value;

        public static bool operator !=(Money a, Money b)
            => a.Value != b.Value;

        public static bool operator >(Money money, object value)
            => (value is Money valueMoney) ? money.Value > valueMoney.Value
                : (value is decimal valueDecimal) ? money.Value > valueDecimal
                : (value is int valueInt) && money.Value > valueInt;

        public static bool operator <(Money money, object value)
            => (value is Money valueMoney) ? money.Value < valueMoney.Value
                : (value is decimal valueDecimal) ? money.Value < valueDecimal
                : (value is int valueInt) && money.Value < valueInt;

        public static bool operator >=(Money money, object value)
            => (value is Money valueMoney) ? money.Value >= valueMoney.Value
                : (value is decimal valueDecimal) ? money.Value >= valueDecimal
                : (value is int valueInt) && money.Value >= valueInt;

        public static bool operator <=(Money money, object value)
            => (value is Money valueMoney) ? money.Value <= valueMoney.Value
                : (value is decimal valueDecimal) ? money.Value <= valueDecimal
                : (value is int valueInt) && money.Value <= valueInt;
        #endregion
    }
}
