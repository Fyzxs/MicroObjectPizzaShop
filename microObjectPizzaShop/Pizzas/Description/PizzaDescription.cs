using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Description.Actions;
using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop;

namespace microObjectPizzaShop.Pizzas.Description
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