using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza.Toppers;

namespace microObjectPizzaShop.Pizza.Description.Actions {
    public interface IPizzaDescriptionAction
    {
        void Act(IWriteString item, IToppings toppings);
    }
}