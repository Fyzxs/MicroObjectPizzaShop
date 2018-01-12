using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas.Description.Actions
{
    public interface IProductDescriptionAction
    {
        void Act(IWriteString item, IToppings toppings);
    }
}