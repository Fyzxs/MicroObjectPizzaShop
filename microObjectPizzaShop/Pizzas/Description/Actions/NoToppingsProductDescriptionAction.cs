using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas.Description.Actions
{
    public class NoToppingsProductDescriptionAction : IProductDescriptionAction
    {
        private static readonly IText NoToppingsFormat = new TextOf("{0}");
        private readonly IProductDescriptionAction _nextAction;
        private readonly IText _text;

        public NoToppingsProductDescriptionAction(IProductType type, IProductDescriptionAction nextAction) :
            this(new FormatText(NoToppingsFormat, type), nextAction)
        { }
        public NoToppingsProductDescriptionAction(IText text, IProductDescriptionAction nextAction)
        {
            _nextAction = nextAction;
            _text = text;
        }
        public void Act(IWriteString item, IToppings toppings)
        {
            if (WriteEmpty(item, toppings)) return;

            _nextAction.Act(item, toppings);
        }

        private bool WriteEmpty(IWriteString item, IToppings toppings)
        {
            if (!toppings.Empty()) return false;

            item.Write(_text.String());
            return true;
        }
    }
}