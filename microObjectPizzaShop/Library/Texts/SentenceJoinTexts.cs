using System.Collections.Generic;
using System.Linq;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Library.Texts {
    public class SentenceJoinTexts : Text
    {
        private readonly List<IText> _toppings;

        public SentenceJoinTexts(List<IText> toppings) => _toppings = toppings;

        public override string String()
        {
            if (_toppings.Count == 0) return string.Empty;
            if (_toppings.Count == 1) return _toppings.First().String();

            string build = _toppings.First().String();
            for (int idx = 1; idx < _toppings.Count - 1; idx++)
            {
                build += ", " + _toppings[idx].String();
            }

            return build + " and " + _toppings.Last().String();
        }
    }
}