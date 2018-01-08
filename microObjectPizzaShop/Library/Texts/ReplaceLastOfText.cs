using MicroObjectPizzaShop.Library.Texts;
using System;

namespace microObjectPizzaShop.Library.Texts
{
    public class ReplaceLastOfText : IText
    {
        private const int NotFound = -1;
        private readonly IText _source;
        private readonly IText _target;
        private readonly IText _replace;

        public ReplaceLastOfText(IText source, IText target, IText replace)
        {
            _source = source;
            _target = target;
            _replace = replace;
        }
        public string String()
        {
            //TODO: This method has a few string operations; can we text-ify?
            string source = _source.String();
            string target = _target.String();

            int place = source.LastIndexOf(target, StringComparison.Ordinal);

            //TODO: Smelly - Make -1 mean something
            return place == NotFound
                ? source
                : source.Remove(place, target.Length).Insert(place, _replace.String());
        }
    }
}