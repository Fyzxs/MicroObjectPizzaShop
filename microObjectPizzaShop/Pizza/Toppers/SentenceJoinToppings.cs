using microObjectPizzaShop.Library.Texts;
using MicroObjectPizzaShop.Library.Texts;
using System.Collections.Generic;

namespace microObjectPizzaShop.Pizza.Toppers
{
    public class SentenceJoinToppings : IText
    {
        private readonly IText _origin;

        public SentenceJoinToppings(IToppings toppings) : this(new ToppingRebaseToText(toppings)) { }
        public SentenceJoinToppings(IEnumerable<IText> toppingNames) : this(new SentenceJoinText(toppingNames)) { }
        public SentenceJoinToppings(IText origin) => _origin = origin;

        public string String() => _origin.String();
    }
}