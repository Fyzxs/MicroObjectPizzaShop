using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace microObjectPizzaShop
{
    [TestClass]
    public class PizzaShopTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldImplementIPizza()
        {
            IPizza subject = new Pizza();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldAddTopping()
        {
            //Arrange
            IPizza subject = new Pizza();

            //Act
            IPizza actual = subject.AddTopping(new TextOf("SomeTopping"));

            //Assert
            actual.Should().NotBeNull();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescription()
        {
            //Arrange
            IPizza subject = new Pizza();

            //Act
            IText actual = subject.Description();

            //Assert
            actual.String().Should().Be("Personal pizza");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescriptionWithTopping()
        {
            //Arrange
            IPizza initial = new Pizza();
            IPizza subject = initial.AddTopping(new TextOf("SomeTopping"));
            //Act
            IText actual = subject.Description();

            //Assert
            actual.String().Should().Be("Personal pizza with SomeTopping");
        }
    }

    public interface IPizza
    {
        IPizza AddTopping(IText topping);
        IText Description();
    }

    public class Pizza : IPizza
    {
        private readonly IText _topping;

        public Pizza() : this(new EmptyText()) { }
        private Pizza(IText topping) => _topping = topping;

        public IPizza AddTopping(IText topping) => new Pizza(topping);
        public IText Description()
        {
            if (new EqualsText(_topping, new EmptyText()).Value()) return new TextOf("Personal pizza");
            return new FormatText(new TextOf("Personal pizza with {0}"), _topping);
        }
    }

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

    public class EqualsText : IScalar<bool>
    {
        private readonly IText _rhs;
        private readonly IText _lhs;

        public EqualsText(IText rhs, IText lhs)
        {
            _rhs = rhs;
            _lhs = lhs;
        }

        public bool Value() => _rhs.String().Equals(_lhs.String());
    }

    public interface IScalar<out T>
    {
        T Value();
    }

    public interface IText
    {
        string String();
    }
    public class EmptyText : IText
    {
        public string String() => string.Empty;
    }
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
