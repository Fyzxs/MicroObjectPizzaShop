using MicroObjectPizzaShop;
using MicroObjectPizzaShop.Library.Texts;
using System.Collections.Generic;
using System.Linq;

namespace microObjectPizzaShop.Library.Texts
{
    public class SentenceJoinToppings : Text
    {
        private readonly List<ITopping> _toppings;

        public SentenceJoinToppings(List<ITopping> toppings) => _toppings = toppings;

        public override string String()
        {
            if (_toppings.Count == 0) return string.Empty;
            if (_toppings.Count == 1) return _toppings.First().Name().String();

            string build = _toppings.First().Name().String();
            for (int idx = 1; idx < _toppings.Count - 1; idx++)
            {
                build += ", " + _toppings[idx].Name().String();
            }

            return build + " and " + _toppings.Last().Name().String();
        }
    }
}