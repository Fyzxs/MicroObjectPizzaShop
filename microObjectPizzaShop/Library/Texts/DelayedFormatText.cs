using MicroObjectPizzaShop.Library.Texts;
using System.Collections.Generic;
using System.Linq;

namespace microObjectPizzaShop.Library.Texts
{
    public class DelayedFormatText : IDelayedFormatText
    {
        private readonly IText _format;
        private readonly IList<IText> _args;
        public DelayedFormatText(IText format, IText arg) : this(format, new List<IText> { arg }) { }

        public DelayedFormatText(IText format, IList<IText> args)
        {
            _format = format;
            _args = args;
        }

        public string String() => string.Format(_format.String(), _args.Select(t => t.String()).ToArray());

        public IDelayedFormatText Add(IText arg)
        {
            List<IText> args = new List<IText>();
            args.AddRange(_args);
            args.Add(arg);
            return new DelayedFormatText(_format, args);
        }
    }
    public interface IDelayedFormatText : IText
    {
        IDelayedFormatText Add(IText arg);
    }
}