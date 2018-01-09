using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza.Description;
using microObjectPizzaShop.Pizza.Toppers;

namespace microObjectPizzaShop.Pizza {
    public interface IPizza
    {
        IDescription Description();
        Money Price();
        IPizza AddTopping(ITopping topping);
    }
}