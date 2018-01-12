using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Description;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas
{
    public abstract class Pizza : IPizza
    {
        private readonly IToppings _toppings;

        protected Pizza(IToppings toppings) => _toppings = toppings;

        public IDescription Description() => new PizzaDescription(Type(), _toppings);

        public IPizza AddTopping(ITopping topping) => NewPizza(_toppings.Add(topping));
        public IPizza RemoveTopping(ITopping topping) => NewPizza(_toppings.Remove(topping));
        public IPizza As(IPizzaType pizzaType) => pizzaType.Create(_toppings.Copy());

        public Money Price() => BasePrice() + _toppings.Cost(BasePrice());

        protected abstract IPizza NewPizza(IToppings toppings);
        protected abstract IPizzaType Type();
        protected abstract Money BasePrice();
    }
}