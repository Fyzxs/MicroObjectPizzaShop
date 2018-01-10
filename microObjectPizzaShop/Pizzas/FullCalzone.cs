using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas {
    public class FullCalzone : Pizza
    {
        public FullCalzone() : this(new Toppings()) { }
        public FullCalzone(IToppings toppings) : base(toppings) { }

        protected override IPizzaType Type() => PizzaType.FullCalzone;
        protected override Money BasePrice() => new Money(14);
        protected override IPizza NewPizza(IToppings toppings) => new FullCalzone(toppings);
    }
}