using System;

namespace microObjectPizzaShop.Library
{
    public class Money
    {
        private readonly double _amount;
        private const double Tolerance = .0001;
        public Money(double amount) => _amount = amount;

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;
            return Equals((Money) other);
        }
        protected bool Equals(Money other) => Math.Abs(other._amount - _amount) < Tolerance;
        public override int GetHashCode() => _amount.GetHashCode();

        public static Money operator +(Money lhs, Money rhs) => new Money(lhs._amount + rhs._amount);
        public static Money operator %(Money lhs, double pct) => new Money(lhs._amount * pct);
    }
}