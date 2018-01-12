using microObjectPizzaShop.Library;
using microObjectPizzaShop.Library.Texts;
using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas.Description.Actions
{
    public class ToppingsProductDescriptionAction : IProductDescriptionAction
    {
        private static readonly IText MultipleToppingsFormat = new TextOf("{0} with {1}");
        private readonly IProductDescriptionAction _nextAction;
        private readonly IDelayedFormatText _formatText;

        public ToppingsProductDescriptionAction(IText type, IProductDescriptionAction nextAction) :
            this(new DelayedFormatText(MultipleToppingsFormat, type), nextAction)
        { }

        public ToppingsProductDescriptionAction(IDelayedFormatText formatText, IProductDescriptionAction nextAction)
        {
            _formatText = formatText;
            _nextAction = nextAction;
        }
        public void Act(IWriteString item, IToppings toppings)
        {
            item.Write(_formatText.Add(toppings.Joined()).String());
            _nextAction.Act(item, toppings);
        }
    }
}