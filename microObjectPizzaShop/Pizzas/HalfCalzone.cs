using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas {
    public class HalfCalzone : Pizza
    {
        public HalfCalzone() : this(new Toppings()) { }
        public HalfCalzone(IToppings toppings) : base(toppings) { }

        protected override IPizzaType Type() => PizzaType.HalfCalzone;
        protected override Money BasePrice() => new Money(8);
        protected override IPizza NewPizza(IToppings toppings) => new HalfCalzone(toppings);
    }
}