namespace microObjectPizzaShop.Library {
    public class EqualsText : IScalar<bool>
    {
        private readonly IText _rhs;
        private readonly IText _lhs;

        public EqualsText(IText rhs, IText lhs)
        {
            _rhs = rhs;
            _lhs = lhs;
        }

        public bool Value() => _rhs.String().Equals(_lhs.String());
    }
}