using System.Linq;

namespace MicroObjectPizzaShop.Library.Texts
{
    public class FormatText : IText
    {
        private readonly IText _format;
        private readonly IText[] _args;

        public FormatText(IText format, params IText[] args)
        {
            _format = format;
            _args = args;
        }

        public string String() => string.Format(_format.String(), Rebase());
        private string[] Rebase() => _args.Select(s => s.String()).ToArray();
    }
}