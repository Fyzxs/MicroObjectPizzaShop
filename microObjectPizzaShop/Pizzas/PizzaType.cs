using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop.Library.Texts;
using System;

namespace microObjectPizzaShop.Pizzas
{
    public class PizzaType : IPizzaType
    {
        public static readonly IPizzaType Large = new PizzaType("Large pizza");
        public static readonly IPizzaType Medium = new MediumPizzaType("Medium pizza");
        public static readonly IPizzaType Personal = new PersonalPizzaType("Personal pizza");
        public static readonly IPizzaType HalfCalzone = new PizzaType("1/2 calzone");
        public static readonly IPizzaType FullCalzone = new PizzaType("Full calzone");
        private readonly IText _type;

        private PizzaType(string type) : this(new TextOf(type)) { }
        private PizzaType(IText type) => _type = type;
        public virtual IPizza Create() { throw new Exception("Soon to be abstract"); }
        public virtual IPizza Create(IToppings copy) { throw new Exception("Soon to be abstract"); }

        public string String() => _type.String();

        private class PersonalPizzaType : PizzaType
        {
            public PersonalPizzaType(string type) : base(type) { }

            public override IPizza Create(IToppings toppings) => new PersonalPizza(toppings);
        }
        private class MediumPizzaType : PizzaType
        {
            public MediumPizzaType(string type) : base(type) { }

            public override IPizza Create(IToppings toppings) => new MediumPizza(toppings);
        }
    }
}