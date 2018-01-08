using microObjectPizzaShop.Library.Texts;
using MicroObjectPizzaShop.Library.Texts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace microObjectPizzaShop.Pizza.Toppers
{
    public class SentenceJoinToppings : IText
    {
        private readonly IText _origin;

        //TODO: Smelly - Logic in Ctor
        public SentenceJoinToppings(IToppings toppings) : this(new ToppingRebaseToText(toppings)) { }
        public SentenceJoinToppings(IEnumerable<IText> toppingNames) : this(new SentenceJoinText(toppingNames)) { }
        public SentenceJoinToppings(IText origin) => _origin = origin;

        public string String() => _origin.String();
    }

    public class ToppingRebaseToText : IEnumerable<IText>
    {
        private readonly IToppings _toppings;

        public ToppingRebaseToText(IToppings toppings) => _toppings = toppings;
        public IEnumerator<IText> GetEnumerator() => _toppings.Select(topping => topping.Name()).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}