using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas
{
    public interface IPizzaType : IText
    {
        IPizza Create(IToppings copy);
    }
}