using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas.Description.Actions
{
    public class ProductDescriptionAction : IProductDescriptionAction
    {
        private readonly IProductDescriptionAction _nextAction;

        public ProductDescriptionAction(IProductType type) : this(
            new NoToppingsProductDescriptionAction(type,
                new ToppingsProductDescriptionAction(type,
                    new NoOp())))
        { }
        private ProductDescriptionAction(IProductDescriptionAction nextAction) => _nextAction = nextAction;

        public void Act(IWriteString item, IToppings toppings) => _nextAction.Act(item, toppings);
        public class NoOp : IProductDescriptionAction
        {
            public void Act(IWriteString item, IToppings toppings) { }
        }
    }
}