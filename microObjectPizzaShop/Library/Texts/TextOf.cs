using System;

namespace MicroObjectPizzaShop.Library.Texts
{
    public class TextOf : Text
    {
        private readonly Text _origin;

        private class DelayedText : Text
        {
            private readonly Func<string> _origin;
            public DelayedText(Func<string> origin) => _origin = origin;
            public override string String() => _origin();
        }

        public TextOf(string origin) : this(new DelayedText(() => origin)) { }

        public TextOf(Text origin) => _origin = origin;

        public override string String() => _origin.String();
    }
}