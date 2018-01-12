using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas
{
    public class MediumPizza : Pizza
    {
        public MediumPizza() : this(new Toppings()) { }
        public MediumPizza(IToppings toppings) : base(toppings) { }

        protected override IPizzaType Type() => PizzaType.Medium;
        protected override Money BasePrice() => new Money(13.00);
    }
}