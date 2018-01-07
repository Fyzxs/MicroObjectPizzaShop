using System.Collections.Generic;
using System.Linq;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Library.Texts {
    public class JoinText : IText
    {
        private readonly IText _seperator;
        private readonly IEnumerable<IText> _enumerable;

        public JoinText(IEnumerable<IText> enumerable) : this(new TextOf(", "), enumerable) { }
        public JoinText(IText seperator, IEnumerable<IText> enumerable)
        {
            _seperator = seperator;
            _enumerable = enumerable;
        }
        public string String() => string.Join(_seperator.String(), _enumerable.Select(t => t.String()));
    }
}