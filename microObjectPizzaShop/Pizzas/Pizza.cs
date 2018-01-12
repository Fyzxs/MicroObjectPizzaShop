using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Description;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas
{
    public class Pizza : IPizza
    {
        private readonly IPizzaType _type;
        private readonly Money _basePrice;
        private readonly IToppings _toppings;

        public Pizza(IPizzaType type, Money basePrice) : this(type, basePrice, new Toppings()) { }
        public Pizza(IPizzaType type, Money basePrice, IToppings toppings)
        {
            _type = type;
            _basePrice = basePrice;
            _toppings = toppings;
        }

        public IDescription Description() => new PizzaDescription(_type, _toppings);

        public IPizza AddTopping(ITopping topping) => _type.Create(_toppings.Add(topping));
        public IPizza RemoveTopping(ITopping topping) => _type.Create(_toppings.Remove(topping));
        public IPizza As(IPizzaType pizzaType) => pizzaType.Create(_toppings.Copy());
        public Money Price() => _basePrice + _toppings.Cost(_basePrice);
    }
    public interface IPizza
    {
        IDescription Description();
        Money Price();
        IPizza AddTopping(ITopping topping);
        IPizza RemoveTopping(ITopping topping);
        IPizza As(IPizzaType pizzaType);
    }
}