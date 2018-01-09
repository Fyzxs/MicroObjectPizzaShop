using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza.Toppers;

namespace microObjectPizzaShop.Pizza {
    public class PersonalPizza : Pizza
    {
        public PersonalPizza() : this(new Toppings()) { }
        public PersonalPizza(IToppings toppings) : base(toppings) { }

        protected override IPizzaType Type() => PizzaType.Personal;
        protected override Money BasePrice() => new Money(9);
        protected override IPizza NewPizza(IToppings toppings) => new PersonalPizza(toppings);
    }
}