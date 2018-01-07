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
            IPizza subject = initial.AddTopping(new Topping(new TextOf("SomeTopping"), .1));
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
            IPizza subject = initial.AddTopping(new Topping(new TextOf("SomeTopping"), .1));

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
            IPizza subject = initial
                .AddTopping(new Topping(new TextOf("SomeTopping"), .1))
                .AddTopping(new Topping(new TextOf("OtherTopping"), .1));

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
            IPizza subject = initial
                .AddTopping(new Topping(new TextOf("SomeTopping"), .1))
                .AddTopping(new Topping(new TextOf("OtherTopping"), .1));

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
            IPizza subject = initial
                .AddTopping(new Topping(new TextOf("SomeTopping"), .1))
                .AddTopping(new Topping(new TextOf("OtherTopping"), .1))
                .AddTopping(new Topping(new TextOf("Delicious"), .1));

            //Act
            IText actual = subject.Description();

            //Assert
            actual.String().Should().Be("Personal pizza with SomeTopping, OtherTopping and Delicious");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceForMeatAndNonMeatTopping()
        {
            //Arrange
            IPizza initial = new Pizza();
            IPizza subject = initial
                .AddTopping(new Topping(new TextOf("MeatTopping"), .15))
                .AddTopping(new Topping(new TextOf("NonMeat"), .1));

            //Act
            IText val = subject.Price();

            //Assert
            val.String().Should().Be("$11.25");
        }
    }

    public class Topping : ITopping
    {
        private readonly IText _name;
        private readonly double _percent;

        public Topping(IText name, double percent)
        {
            _name = name;
            _percent = percent;
        }

        public double Cost(double pizzaCost) => pizzaCost * _percent;
        public IText Name() => _name;
    }

    public interface ITopping
    {
        double Cost(double pizzaCost);
        IText Name();
    }

    public interface IPizza
    {
        IText Description();
        IText Price();
        IPizza AddTopping(ITopping topping);
    }

    public class Pizza : IPizza
    {
        private static readonly IText PizzaType = new TextOf("Personal pizza");
        private static readonly IText Format = new TextOf("{0} with {1}");

        private readonly List<ITopping> _toppings;

        public Pizza() : this(new List<ITopping>()) { }
        private Pizza(List<ITopping> toppings) => _toppings = toppings;

        public IText Description()
        {
            if (!_toppings.Any()) return PizzaType;
            List<IText> texts = new List<IText>
            {
                PizzaType,
                new SentenceJoinToppings(_toppings)
            };
            return new FormatText(Format, texts.ToArray());
        }

        public IPizza AddTopping(ITopping topping)
        {
            _toppings.Add(topping);
            return new Pizza(_toppings);
        }

        public IText Price()
        {
            double cost = 0;
            foreach (ITopping topping in _toppings)
            {
                cost += topping.Cost(9);
            }

            return new TextOf(( 9 + cost ).ToString("C"));
        }
    }
}