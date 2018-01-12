using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas
{
    public interface IPizzaType : IProductType
    {
        IPizza Create();
        IPizza Create(IToppings copy);
    }

    public interface IProductType : IText { }
}