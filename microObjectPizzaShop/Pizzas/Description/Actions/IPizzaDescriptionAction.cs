using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas.Description.Actions {
    public interface IPizzaDescriptionAction
    {
        void Act(IWriteString item, IToppings toppings);
    }
}