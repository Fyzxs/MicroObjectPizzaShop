using FluentAssertions;
using microObjectPizzaShop.Library.Texts;
using MicroObjectPizzaShop.Library.Texts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MicroObjectPizzaShop
{
    [TestClass]
    public class PizzaShopTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescriptionWithNoToppings()
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

        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceWithNoTopping()
        {
            //Arrange
            IPizza subject = new Pizza();

            //Act
            IText val = subject.Price();

            //Assert
            val.String().Should().Be("$9.00");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceWithTopping()
        {
            //Arrange
            IPizza initial = new Pizza();
            IPizza subject = initial.AddTopping(new TextOf("SomeTopping"));

            //Act
            IText val = subject.Price();

            //Assert
            val.String().Should().Be("$9.90");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceWithMultipleToppings()
        {
            //Arrange
            IPizza initial = new Pizza();
            IPizza subject = initial.AddTopping(new TextOf("SomeTopping")).AddTopping(new TextOf("OtherTopping"));

            //Act
            IText actual = subject.Price();

            //Assert
            actual.String().Should().Be("$10.80");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvideDescriptionWithTwoToppings()
        {
            //Arrange
            IPizza initial = new Pizza();
            IPizza subject = initial.AddTopping(new TextOf("SomeTopping")).AddTopping(new TextOf("OtherTopping"));

            //Act
            IText actual = subject.Description();

            //Assert
            actual.String().Should().Be("Personal pizza with SomeTopping and OtherTopping");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvideDescriptionWithThreeToppings()
        {
            //Arrange
            IPizza initial = new Pizza();
            IPizza subject = initial.AddTopping(new TextOf("SomeTopping"))
                .AddTopping(new TextOf("OtherTopping"))
                .AddTopping(new TextOf("Delicious"));

            //Act
            IText actual = subject.Description();

            //Assert
            actual.String().Should().Be("Personal pizza with SomeTopping, OtherTopping and Delicious");
        }
    }
    public interface IPizza
    {
        IPizza AddTopping(IText topping);
        IText Description();
        IText Price();
    }

    public class Pizza : IPizza
    {
        private static readonly IText PizzaType = new TextOf("Personal pizza");
        private static readonly IText Format = new TextOf("{0} with {1}");

        private readonly List<IText> _toppings;

        public Pizza() : this(new List<IText>()) { }
        private Pizza(List<IText> toppings) => _toppings = toppings;

        public IPizza AddTopping(IText topping)
        {
            _toppings.Add(topping);
            return new Pizza(_toppings);
        }

        public IText Description()
        {
            if (!_toppings.Any()) return PizzaType;
            List<IText> texts = new List<IText> { PizzaType, new SentenceJoinTexts(_toppings) };
            return new FormatText(Format, texts.ToArray());
        }

        public IText Price() => new TextOf(( 9 + _toppings.Count * .9 ).ToString("C"));
    }
}
