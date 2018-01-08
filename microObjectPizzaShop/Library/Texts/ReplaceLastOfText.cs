using MicroObjectPizzaShop.Library.Texts;
using System;

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

    public class InsertText : IText
    {
        private const int NotFound = -1;
        private readonly IText _source;
        private readonly IInteger _index;
        private readonly IText _target;

        public InsertText(IText source, IInteger index, IText target)
        {
            _source = source;
            _index = index;
            _target = target;
        }

        public string String()
        {
            int lastIndexOf = _index.Value();
            if (lastIndexOf == NotFound) return _source.String();

            return _source.String().Insert(_index.Value(), _target.String());
        }
    }

    public class RemoveText : IText
    {
        private const int NotFound = -1;

        private readonly IText _source;
        private readonly IInteger _lastIndexOf;
        private readonly IInteger _lengthOf;

        public RemoveText(IText source, IText target) :
            this(source, new LastIndexOf(source, target), new LengthOf(target))
        { }
        public RemoveText(IText source, IInteger lastIndexOf, IInteger lengthOf)
        {
            _source = source;
            _lastIndexOf = lastIndexOf;
            _lengthOf = lengthOf;
        }

        public string String()
        {
            int lastIndexOf = _lastIndexOf.Value();
            if (lastIndexOf == NotFound) return _source.String();

            return _source.String().Remove(lastIndexOf, _lengthOf.Value());
        }
    }

    public class LastIndexOf : IInteger
    {
        private readonly IText _source;
        private readonly IText _target;

        public LastIndexOf(IText source, IText target)
        {
            _source = source;
            _target = target;
        }

        public int Value() => _source.String().LastIndexOf(_target.String(), StringComparison.Ordinal);
    }

    public class LengthOf : IInteger
    {
        private readonly IText _origin;

        public LengthOf(IText origin) => _origin = origin;

        public int Value() => _origin.String().Length;
    }

    public interface IInteger
    {
        int Value();
    }

    public class IntegerOf : IInteger
    {
        private readonly int _origin;

        public IntegerOf(int origin) => _origin = origin;

        public int Value() => _origin;
    }
}