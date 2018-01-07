using MicroObjectPizzaShop.Library.Texts;
using System;

namespace microObjectPizzaShop.Library.Texts
{
    public class ReplaceLastOfText : IText
    {
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
            string source = _source.String();
            string target = _target.String();
            string replace = _replace.String();

            int place = source.LastIndexOf(target, StringComparison.Ordinal);

            //TODO: Smelly - Make -1 mean something
            return place == -1
                ? source
                : source.Remove(place, target.Length).Insert(place, replace);
        }
    }
}