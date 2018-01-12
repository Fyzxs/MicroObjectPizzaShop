using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Description;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas
{
    public interface IPizza
    {
        IDescription Description();
        Money Price();
        IPizza AddTopping(ITopping topping);
        IPizza RemoveTopping(ITopping topping);
        IPizza As(IPizzaType pizzaType);
    }
}