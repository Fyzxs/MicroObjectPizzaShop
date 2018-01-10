using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas.Description.Actions {
    public class NoToppingsPizzaDescriptionAction : IPizzaDescriptionAction
    {
        private static readonly IText NoToppingsFormat = new TextOf("{0} pizza");
        private readonly IPizzaDescriptionAction _nextAction;
        private readonly IText _text;

        public NoToppingsPizzaDescriptionAction(IPizzaType type, IPizzaDescriptionAction nextAction) :
            this(new FormatText(NoToppingsFormat, type), nextAction)
        { }
        public NoToppingsPizzaDescriptionAction(IText text, IPizzaDescriptionAction nextAction)
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