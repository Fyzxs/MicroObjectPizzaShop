using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop;

namespace microObjectPizzaShop.Pizzas.Description.Actions {
    public class PizzaDescriptionAction : IPizzaDescriptionAction
    {
        private readonly IPizzaDescriptionAction _nextAction;

        public PizzaDescriptionAction(IPizzaType type) : this(
            new NoToppingsPizzaDescriptionAction(type,
                new ToppingsPizzaDescriptionAction(type,
                    new NoOp())))
        { }
        private PizzaDescriptionAction(IPizzaDescriptionAction nextAction) => _nextAction = nextAction;

        public void Act(IWriteString item, IToppings toppings) => _nextAction.Act(item, toppings);
        public class NoOp : IPizzaDescriptionAction
        {
            public void Act(IWriteString item, IToppings toppings) { }
        }
    }
}