using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas.Toppers {
    public class ToppingRebaseToText : IEnumerable<IText>
    {
        private readonly IToppings _toppings;

        public ToppingRebaseToText(IToppings toppings) => _toppings = toppings;
        public IEnumerator<IText> GetEnumerator() => _toppings.Select(topping => topping.Name()).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}