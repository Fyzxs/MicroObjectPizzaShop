using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza.Description.Actions;
using microObjectPizzaShop.Pizza.Toppers;
using MicroObjectPizzaShop;

namespace microObjectPizzaShop.Pizza.Description
{
    public class PizzaDescription : IDescription
    {
        private readonly IPizzaDescriptionAction _pizzaDescriptionAction;
        private readonly IToppings _toppings;

        public PizzaDescription(IPizzaType type, IToppings toppings) :
            this(new PizzaDescriptionAction(type), toppings)
        { }
        public PizzaDescription(IPizzaDescriptionAction pizzaDescriptionAction, IToppings toppings)
        {
            _pizzaDescriptionAction = pizzaDescriptionAction;
            _toppings = toppings;
        }

        public void Into(IWriteString item) => _pizzaDescriptionAction.Act(item, _toppings);
    }
    public interface IDescription
    {
        void Into(IWriteString item);
    }
}