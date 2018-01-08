using MicroObjectPizzaShop.Library.Texts;
using microObjectPizzaShop.Library.Numeric;

namespace microObjectPizzaShop.Library.Texts
{
    public class ReplaceLastOfText : IText
    {
        private readonly IText _origin;

        public ReplaceLastOfText(IText source, IText target, IText replace) :
            this(new InsertText(new RemoveText(source, target), new LastIndexOf(source, target), replace))
        { }
        public ReplaceLastOfText(IText text) => _origin = text;

        public string String() => _origin.String();
    }
}