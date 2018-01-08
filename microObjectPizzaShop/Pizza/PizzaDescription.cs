using microObjectPizzaShop.Library;
using microObjectPizzaShop.Library.Texts;
using microObjectPizzaShop.Pizza.Toppers;
using MicroObjectPizzaShop;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizza
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

    public interface IPizzaDescriptionAction
    {
        void Act(IWriteString item, IToppings toppings);
    }

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
    public class ToppingsPizzaDescriptionAction : IPizzaDescriptionAction
    {
        private static readonly IText MultipleToppingsFormat = new TextOf("{0} pizza with {1}");
        private readonly IPizzaDescriptionAction _nextAction;
        private readonly IDelayedFormatText _formatText;

        public ToppingsPizzaDescriptionAction(IPizzaType type, IPizzaDescriptionAction nextAction) :
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

    public interface IDescription
    {
        void Into(IWriteString item);
    }
}