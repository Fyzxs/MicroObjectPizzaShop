using System.Linq;

namespace microObjectPizzaShop.Library
{
    public class FormatText : Text
    {
        private readonly Text _format;
        private readonly Text[] _args;

        public FormatText(Text format, params Text[] args)
        {
            _format = format;
            _args = args;
        }

        public override string String() => string.Format(_format.String(), Rebase());
        private string[] Rebase() => _args.Select(s => s.String()).ToArray();
    }
}