using MicroObjectPizzaShop.Library.Texts;
using System.Collections.Generic;
using System.Linq;

namespace microObjectPizzaShop.Library.Texts
{
    public class JoinText : IText
    {
        private readonly IText _seperator;
        private readonly IEnumerable<IText> _enumerable;

        public JoinText(IText seperator, IEnumerable<IText> enumerable)
        {
            _seperator = seperator;
            _enumerable = enumerable;
        }
        public string String() => string.Join(_seperator.String(), _enumerable.Select(t => t.String()));
    }
}