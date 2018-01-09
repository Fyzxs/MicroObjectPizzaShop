using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza.Toppers;

namespace microObjectPizzaShop.Pizza
{
    public class LargePizza : Pizza
    {
        public LargePizza() : this(new Toppings()) { }
        public LargePizza(IToppings toppings) : base(toppings) { }

        protected override IPizzaType Type() => PizzaType.Large;
        protected override Money BasePrice() => new Money(18);
        protected override IPizza NewPizza(IToppings toppings) => new LargePizza(toppings);
    }
}