using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            IPizza actual = subject.AddTopping("SomeTopping");

            //Assert
            actual.Should().NotBeNull();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescription()
        {
            //Arrange
            IPizza subject = new Pizza();

            //Act
            string actual = subject.Description();

            //Assert
            actual.Should().Be("Personal pizza");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescriptionWithTopping()
        {
            //Arrange
            IPizza initial = new Pizza();
            IPizza subject = initial.AddTopping("SomeTopping");
            //Act
            string actual = subject.Description();

            //Assert
            actual.Should().Be("Personal pizza with SomeTopping");
        }
    }

    public interface IPizza
    {
        IPizza AddTopping(string topping);
        string Description();
    }

    public class Pizza : IPizza
    {
        private readonly string _topping;

        public Pizza() : this(string.Empty) { }
        private Pizza(string topping) => _topping = topping;

        public IPizza AddTopping(string topping) => new Pizza(topping);
        public string Description()
        {
            if (string.IsNullOrWhiteSpace(_topping)) return "Personal pizza";
            return $"Personal pizza with {_topping}";
        }
    }

    public interface IText
    {
        string String();
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
