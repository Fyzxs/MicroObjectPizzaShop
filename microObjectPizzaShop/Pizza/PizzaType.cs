using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizza
{
    public class PizzaType : IPizzaType
    {
        public static readonly IPizzaType Large = new PizzaType("Large");
        public static readonly IPizzaType Personal = new PizzaType("Personal");

        private readonly IText _type;

        private PizzaType(string type) : this(new TextOf(type)) { }
        private PizzaType(IText type) => _type = type;

        public string String() => _type.String();
    }
}