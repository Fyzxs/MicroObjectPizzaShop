using System;

namespace MicroObjectPizzaShop.Library.Texts
{
    public class TextOf : Text
    {
        private readonly IText _origin;

        private class DelayedText : IText
        {
            private readonly Func<string> _origin;
            public DelayedText(Func<string> origin) => _origin = origin;
            public string String() => _origin();

            public bool IsEmpty() => throw new NotImplementedException("Should never get invoked.");
        }

        public TextOf(string origin) : this(new DelayedText(() => origin)) { }

        public TextOf(IText origin) => _origin = origin;

        public override string String() => _origin.String();
    }
}