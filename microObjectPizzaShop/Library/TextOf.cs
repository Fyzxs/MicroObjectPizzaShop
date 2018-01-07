using System;

namespace microObjectPizzaShop.Library {
    public class TextOf : IText
    {
        private readonly IText _origin;

        private class DelayedText : IText
        {
            private readonly Func<string> _origin;
            public DelayedText(Func<string> origin) => _origin = origin;
            public string String() => _origin();
        }

        public TextOf(string origin) : this(new DelayedText(() => origin)) { }

        public TextOf(IText origin) => _origin = origin;

        public string String() => _origin.String();
    }
}