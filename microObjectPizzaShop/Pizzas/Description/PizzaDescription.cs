using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Description.Actions;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas.Description
{
    public class PizzaDescription : IDescription
    {
        private readonly IProductDescriptionAction _productDescriptionAction;
        private readonly IToppings _toppings;

        public PizzaDescription(IProductType type, IToppings toppings) :
            this(new ProductDescriptionAction(type), toppings)
        { }
        public PizzaDescription(IProductDescriptionAction productDescriptionAction, IToppings toppings)
        {
            _productDescriptionAction = productDescriptionAction;
            _toppings = toppings;
        }

        public void Into(IWriteString item) => _productDescriptionAction.Act(item, _toppings);
    }
    public interface IDescription
    {
        void Into(IWriteString item);
    }
}