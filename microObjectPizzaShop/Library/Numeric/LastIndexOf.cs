using System;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Library.Numeric {
    public class LastIndexOf : IInteger
    {
        private readonly IText _source;
        private readonly IText _target;

        public LastIndexOf(IText source, IText target)
        {
            _source = source;
            _target = target;
        }

        public int Value() => _source.String().LastIndexOf(_target.String(), StringComparison.Ordinal);
    }
}