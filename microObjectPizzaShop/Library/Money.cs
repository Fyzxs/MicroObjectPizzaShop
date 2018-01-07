namespace microObjectPizzaShop.Library {
    public class Money
    {
        private readonly double _amount;
        public Money(double amount) => _amount = amount;

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;
            return Equals((Money) other);
        }
        protected bool Equals(Money other) => _amount.Equals(other._amount);
        public override int GetHashCode() => _amount.GetHashCode();

        public static Money operator +(Money lhs, Money rhs) => new Money(lhs._amount + rhs._amount);
        public static Money operator %(Money lhs, double pct) => new Money(lhs._amount * pct);
    }
}