namespace microObjectPizzaShop.Library.Numeric {
    public class IntegerOf : IInteger
    {
        private readonly int _origin;

        public IntegerOf(int origin) => _origin = origin;

        public int Value() => _origin;
    }
}