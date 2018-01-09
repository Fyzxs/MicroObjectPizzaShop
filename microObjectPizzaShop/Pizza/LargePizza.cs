using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza.Toppers;

namespace microObjectPizzaShop.Pizza
{
    public class FamilyPizza : Pizza
    {
        public FamilyPizza() : this(new Toppings()) { }
        public FamilyPizza(IToppings toppings) : base(toppings) { }

        protected override IPizzaType Type() => PizzaType.Family;
        protected override Money BasePrice() => new Money(18);
        protected override IPizza NewPizza(IToppings toppings) => new FamilyPizza(toppings);
    }
}