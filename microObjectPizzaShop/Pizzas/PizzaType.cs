using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas
{
    public class PizzaType : IPizzaType
    {
        public static readonly IPizzaType Large = new PizzaType("Large pizza");
        public static readonly IPizzaType Medium = new PizzaType("Medium pizza");
        public static readonly IPizzaType Personal = new PizzaType("Personal pizza");
        public static readonly IPizzaType HalfCalzone = new PizzaType("1/2 calzone");
        public static readonly IPizzaType FullCalzone = new PizzaType("Full calzone");
        private readonly IText _type;

        private PizzaType(string type) : this(new TextOf(type)) { }
        private PizzaType(IText type) => _type = type;

        public string String() => _type.String();
    }
}