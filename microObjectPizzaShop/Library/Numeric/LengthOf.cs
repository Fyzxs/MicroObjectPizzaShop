using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Library.Numeric {
    public class LengthOf : IInteger
    {
        private readonly IText _origin;

        public LengthOf(IText origin) => _origin = origin;

        public int Value() => _origin.String().Length;
    }
}