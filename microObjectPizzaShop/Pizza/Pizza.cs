using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza.Description;
using microObjectPizzaShop.Pizza.Toppers;

namespace microObjectPizzaShop.Pizza {
    public abstract class Pizza : IPizza
    {
        private readonly IToppings _toppings;

        protected Pizza(IToppings toppings) => _toppings = toppings;

        public IDescription Description() => new PizzaDescription(Type(), _toppings);

        public IPizza AddTopping(ITopping topping) => NewPizza(_toppings.Add(topping));

        public Money Price() => BasePrice() + _toppings.Cost(BasePrice());

        protected abstract IPizza NewPizza(IToppings toppings);
        protected abstract IPizzaType Type();
        protected abstract Money BasePrice();
    }
}