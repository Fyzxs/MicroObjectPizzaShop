using System.Collections.Generic;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Library.Texts {
    public class SentenceJoinText : IText
    {
        private readonly IText _origin;

        public SentenceJoinText(IEnumerable<IText> enumerable) :
            this(new TextOf(", "), enumerable)
        { }

        public SentenceJoinText(IText seperator, IEnumerable<IText> enumerable) :
            this(seperator, new TextOf(" and "), new JoinText(seperator, enumerable))
        { }
        public SentenceJoinText(IText seperator, IText replace, IText joinText) :
            this(new ReplaceLastOfText(joinText, seperator, replace))
        { }
        public SentenceJoinText(IText text) => _origin = text;

        public string String() => _origin.String();
    }
}