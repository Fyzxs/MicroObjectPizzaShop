using System.Linq;
using microObjectPizzaShop.Library.Texts;
using MicroObjectPizzaShop;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizza
{
    public class SentenceJoinToppings : IText
    {
        private readonly IText _origin;

        public SentenceJoinToppings(IToppings toppings) : this(new SentenceJoinText(toppings.Select(t => t.Name()))) { }

        public SentenceJoinToppings(IText origin) => _origin = origin;

        public string String() => _origin.String();
    }
}