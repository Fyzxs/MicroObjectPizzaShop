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
            IPizza subject = new PersonalPizza();

            //Act
            IText actual = subject.Description();

            //Assert
            actual.String().Should().Be("Personal pizza");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescriptionWithTopping()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
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
            IPizza subject = new PersonalPizza();

            //Act
            IText val = subject.Price();

            //Assert
            val.String().Should().Be("$9.00");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceWithTopping()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
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
            IPizza initial = new PersonalPizza();
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
            IPizza initial = new PersonalPizza();
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
            IPizza initial = new PersonalPizza();
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
            IPizza initial = new PersonalPizza();
            IPizza subject = initial
                .AddTopping(new Topping(new TextOf("MeatTopping"), .15))
                .AddTopping(new Topping(new TextOf("NonMeat"), .1));

            //Act
            IText val = subject.Price();

            //Assert
            val.String().Should().Be("$11.25");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveFamilyPizza()
        {
            //Arrange
            IPizza subject = new FamilyPizza();

            //Act
            IText val = subject.Price();

            //Assert
            val.String().Should().Be("$18.00");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvideFamilyPriceWithTopping()
        {
            //Arrange
            IPizza initial = new FamilyPizza();
            IPizza subject = initial.AddTopping(new Topping(new TextOf("SomeTopping"), .15));

            //Act
            IText val = subject.Price();

            //Assert
            val.String().Should().Be("$20.70");
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayFamilyDescriptionWithNoToppings()
        {
            //Arrange
            IPizza subject = new FamilyPizza();

            //Act
            IText actual = subject.Description();

            //Assert
            actual.String().Should().Be("Family pizza");
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldHaveImmutableToppings()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
            IPizza second = initial.AddTopping(new Topping(new TextOf("NonMeat"), .1));

            //Act
            IText initialPrice = initial.Price();
            IText secondPrice = second.Price();

            //Assert
            initialPrice.String().Should().NotBe(secondPrice.String());
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


    public class FamilyPizza : PersonalPizza
    {
        public FamilyPizza() : this(new List<ITopping>()) { }
        public FamilyPizza(List<ITopping> list) : base(list) { }

        protected override IText Name() => new TextOf("Family");
        protected override double BasePrice() => 18;
        protected override IPizza NewPizza(List<ITopping> toppings) => new FamilyPizza(toppings);
    }

    public class PersonalPizza : Pizza
    {
        public PersonalPizza() : this(new List<ITopping>()) { }
        public PersonalPizza(List<ITopping> list) : base(list) { }

        protected override IText Name() => new TextOf("Personal");
        protected override double BasePrice() => 9;
        protected override IPizza NewPizza(List<ITopping> toppings) => new PersonalPizza(toppings);
    }

    public abstract class Pizza : IPizza
    {
        private static readonly IText NoToppingsFormat = new TextOf("{0} pizza");
        private static readonly IText MultipleToppingsFormat = new TextOf("{0} pizza with {1}");

        private readonly List<ITopping> _toppings;
        protected Pizza(List<ITopping> toppings) => _toppings = toppings;


        public IText Description()
        {
            if (!_toppings.Any()) return new FormatText(NoToppingsFormat, Name());
            List<IText> texts = new List<IText>
            {
                Name(),
                new SentenceJoinToppings(_toppings)
            };
            return new FormatText(MultipleToppingsFormat, texts.ToArray());
        }

        public IPizza AddTopping(ITopping topping)
        {
            List<ITopping> toppings = new List<ITopping>();
            toppings.AddRange(_toppings);
            toppings.Add(topping);
            return NewPizza(toppings);
        }

        public IText Price()
        {
            double cost = 0;
            foreach (ITopping topping in _toppings)
            {
                double basePrice = BasePrice();
                cost += topping.Cost(basePrice);
            }

            return new TextOf(( BasePrice() + cost ).ToString("C"));
        }

        protected abstract IPizza NewPizza(List<ITopping> toppings);
        protected abstract IText Name();
        protected abstract double BasePrice();
    }

    public class Toppings : IToppings
    {
        private readonly List<ITopping> _toppings;

        public Toppings() : this(new List<ITopping>())
        {

        }

        public Toppings(List<ITopping> toppings) => _toppings = toppings;

        public bool Any() => _toppings.Any();

    }

    public interface IToppings { }
}