using microObjectPizzaShop.Library.Numeric;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Library.Texts {
    public class RemoveText : IText
    {
        private const int NotFound = -1;

        private readonly IText _source;
        private readonly IInteger _lastIndexOf;
        private readonly IInteger _lengthOf;

        public RemoveText(IText source, IText target) :
            this(source, new LastIndexOf(source, target), new LengthOf(target))
        { }
        public RemoveText(IText source, IInteger lastIndexOf, IInteger lengthOf)
        {
            _source = source;
            _lastIndexOf = lastIndexOf;
            _lengthOf = lengthOf;
        }

        public string String()
        {
            int lastIndexOf = _lastIndexOf.Value();
            if (lastIndexOf == NotFound) return _source.String();

            return _source.String().Remove(lastIndexOf, _lengthOf.Value());
        }
    }
}