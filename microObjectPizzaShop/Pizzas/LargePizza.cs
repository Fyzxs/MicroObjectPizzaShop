using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas
{
    public class LargePizza : Pizza
    {
        public LargePizza() : this(new Toppings()) { }
        public LargePizza(IToppings toppings) : base(toppings) { }

        protected override IPizzaType Type() => PizzaType.Large;
        protected override Money BasePrice() => new Money(18);
    }
}