using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza;
using microObjectPizzaShop.Pizza.Toppers;

namespace microObjectPizzaShop {
    public class MediumPizza : Pizza.Pizza
    {
        public MediumPizza() : this(new Toppings()) { }
        public MediumPizza(IToppings toppings) : base(toppings) { }

        protected override IPizzaType Type() => PizzaType.Medium;
        protected override Money BasePrice() => new Money(13.00);
        protected override IPizza NewPizza(IToppings toppings) => new MediumPizza(toppings);
    }
}