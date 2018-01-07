using System.Linq;
using microObjectPizzaShop.Library.Texts;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizza.Toppers
{
    public class SentenceJoinToppings : IText
    {
        private readonly IText _origin;

        //TODO: Smelly - Logic in Ctor
        public SentenceJoinToppings(IToppings toppings) : this(new SentenceJoinText(toppings.Select(t => t.Name()))) { }

        public SentenceJoinToppings(IText origin) => _origin = origin;

        public string String() => _origin.String();
    }
}