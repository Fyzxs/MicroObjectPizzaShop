using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas {
    public class PersonalPizza : Pizza
    {
        public PersonalPizza() : this(new Toppings()) { }
        public PersonalPizza(IToppings toppings) : base(toppings) { }

        protected override IPizzaType Type() => PizzaType.Personal;
        protected override Money BasePrice() => new Money(9);
        protected override IPizza NewPizza(IToppings toppings) => new PersonalPizza(toppings);
    }
}