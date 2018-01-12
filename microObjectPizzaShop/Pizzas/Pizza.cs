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

        public IPizza AddTopping(ITopping topping) => Type().Create(_toppings.Add(topping));
        public IPizza RemoveTopping(ITopping topping) => Type().Create(_toppings.Remove(topping));
        public IPizza As(IPizzaType pizzaType) => pizzaType.Create(_toppings.Copy());

        public Money Price() => BasePrice() + _toppings.Cost(BasePrice());

        protected abstract IPizzaType Type();
        protected abstract Money BasePrice();
    }
    public abstract class Calzone : ICalzone
    {
        private readonly IToppings _toppings;

        protected Calzone(IToppings toppings) => _toppings = toppings;

        public IDescription Description() => new PizzaDescription(Type(), _toppings);

        public ICalzone AddTopping(ITopping topping) => Type().Create(_toppings.Add(topping));
        public ICalzone RemoveTopping(ITopping topping) => Type().Create(_toppings.Remove(topping));
        public ICalzone As(ICalzoneType calzoneType) => calzoneType.Create(_toppings.Copy());

        public Money Price() => BasePrice() + _toppings.Cost(BasePrice());

        protected abstract ICalzoneType Type();
        protected abstract Money BasePrice();
    }
}