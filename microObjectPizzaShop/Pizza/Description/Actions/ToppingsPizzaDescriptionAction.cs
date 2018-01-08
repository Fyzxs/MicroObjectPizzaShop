using microObjectPizzaShop.Library;
using microObjectPizzaShop.Library.Texts;
using microObjectPizzaShop.Pizza.Toppers;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizza.Description.Actions {
    public class ToppingsPizzaDescriptionAction : IPizzaDescriptionAction
    {
        private static readonly IText MultipleToppingsFormat = new TextOf("{0} pizza with {1}");
        private readonly IPizzaDescriptionAction _nextAction;
        private readonly IDelayedFormatText _formatText;

        public ToppingsPizzaDescriptionAction(IText type, IPizzaDescriptionAction nextAction) :
            this(new DelayedFormatText(MultipleToppingsFormat, type), nextAction)
        { }

        public ToppingsPizzaDescriptionAction(IDelayedFormatText formatText, IPizzaDescriptionAction nextAction)
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