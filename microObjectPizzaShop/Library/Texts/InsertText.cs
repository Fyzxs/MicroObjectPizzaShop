using microObjectPizzaShop.Library.Numeric;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Library.Texts {
    public class InsertText : IText
    {
        private const int NotFound = -1;
        private readonly IText _source;
        private readonly IInteger _index;
        private readonly IText _target;

        public InsertText(IText source, IInteger index, IText target)
        {
            _source = source;
            _index = index;
            _target = target;
        }

        public string String()
        {
            int lastIndexOf = _index.Value();
            if (lastIndexOf == NotFound) return _source.String();

            return _source.String().Insert(_index.Value(), _target.String());
        }
    }
}