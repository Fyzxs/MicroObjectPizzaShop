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
            IPizza pizza = new PersonalPizza();
            IDescription actual = pizza.Description();
            TestWriteText testWriteText = new TestWriteText();

            //Act
            actual.Into(testWriteText);

            //Assert
            testWriteText.AssertValueIs("Personal pizza");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescriptionWithTopping()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
            IPizza pizza = initial.AddTopping(new Topping(new TextOf("SomeTopping"), .1));
            IDescription actual = pizza.Description();
            TestWriteText testWriteText = new TestWriteText();

            //Act
            actual.Into(testWriteText);

            //Assert
            testWriteText.AssertValueIs("Personal pizza with SomeTopping");
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
            IPizza pizza = initial
                .AddTopping(new Topping(new TextOf("SomeTopping"), .1))
                .AddTopping(new Topping(new TextOf("OtherTopping"), .1));
            IDescription actual = pizza.Description();
            TestWriteText testWriteText = new TestWriteText();

            //Act
            actual.Into(testWriteText);

            //Assert
            testWriteText.AssertValueIs("Personal pizza with SomeTopping and OtherTopping");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvideDescriptionWithThreeToppings()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
            IPizza pizza = initial
                .AddTopping(new Topping(new TextOf("SomeTopping"), .1))
                .AddTopping(new Topping(new TextOf("OtherTopping"), .1))
                .AddTopping(new Topping(new TextOf("Delicious"), .1));
            IDescription actual = pizza.Description();
            TestWriteText testWriteText = new TestWriteText();

            //Act
            actual.Into(testWriteText);

            //Assert
            testWriteText.AssertValueIs("Personal pizza with SomeTopping, OtherTopping and Delicious");
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
            IText actual = subject.Price();

            //Assert
            actual.String().Should().Be("$18.00");
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
            IPizza pizza = new FamilyPizza();
            IDescription subject = pizza.Description();

            TestWriteText testWriteText = new TestWriteText();

            //Act
            subject.Into(testWriteText);

            //Assert
            testWriteText.AssertValueIs("Family pizza");
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
        IDescription Description();
        IText Price();
        IPizza AddTopping(ITopping topping);
    }


    public class FamilyPizza : PersonalPizza
    {
        public FamilyPizza() : this(new Toppings()) { }
        public FamilyPizza(IToppings toppings) : base(toppings) { }

        protected override IText Name() => new TextOf("Family");
        protected override double BasePrice() => 18;
        protected override IPizza NewPizza(IToppings toppings) => new FamilyPizza(toppings);
    }

    public class PersonalPizza : Pizza
    {
        public PersonalPizza() : this(new Toppings()) { }
        public PersonalPizza(IToppings toppings) : base(toppings) { }

        protected override IText Name() => new TextOf("Personal");
        protected override double BasePrice() => 9;
        protected override IPizza NewPizza(IToppings toppings) => new PersonalPizza(toppings);
    }

    public abstract class Pizza : IPizza
    {
        private readonly IToppings _toppings;

        protected Pizza(IToppings toppings) => _toppings = toppings;

        public IDescription Description() => new PizzaDescription(Name(), _toppings);

        public IPizza AddTopping(ITopping topping) => NewPizza(_toppings.Add(topping));

        public IText Price() => new TextOf(( BasePrice() + _toppings.Cost(BasePrice()) ).ToString("C"));

        protected abstract IPizza NewPizza(IToppings toppings);
        protected abstract IText Name();
        protected abstract double BasePrice();
    }

    public class PizzaDescription : IDescription
    {
        private static readonly IText NoToppingsFormat = new TextOf("{0} pizza");
        private static readonly IText MultipleToppingsFormat = new TextOf("{0} pizza with {1}");

        private readonly IText _type;
        private readonly IToppings _toppings;

        public PizzaDescription(IText type, IToppings toppings)
        {
            _type = type;
            _toppings = toppings;
        }

        public void Into(IWriteText item)
        {
            if (ProcessedNoToppings(item)) return;

            ProcessToppingDescription(item);
        }

        private void ProcessToppingDescription(IWriteText item)
        {
            List<IText> texts = new List<IText>
            {
                _type,
                _toppings.SentenceJoined()
            };
            item.Write(new FormatText(MultipleToppingsFormat, texts.ToArray()).String());
        }

        private bool ProcessedNoToppings(IWriteText item)
        {
            if (!_toppings.Empty()) return false;

            item.Write(new FormatText(NoToppingsFormat, _type).String());
            return true;
        }
    }

    public interface IWriteText
    {
        void Write(string value);
    }
    public class TestWriteText : IWriteText
    {
        private string _value;

        public void Write(string value) => _value = value;

        public void AssertValueIs(string expected) => _value.Should().Be(expected);
    }

    public interface IDescription
    {
        void Into(IWriteText item);
    }

    public class Toppings : IToppings
    {
        private readonly List<ITopping> _toppings;

        public Toppings() : this(new List<ITopping>()) { }

        public Toppings(List<ITopping> toppings) => _toppings = toppings;

        public double Cost(double basePrice) => _toppings.Sum(o => o.Cost(basePrice));

        public bool Empty() => !_toppings.Any();
        public IToppings Add(ITopping topping)
        {
            List<ITopping> toppings = new List<ITopping>();
            toppings.AddRange(_toppings);
            toppings.Add(topping);
            return new Toppings(toppings);
        }

        public IText SentenceJoined() => new SentenceJoinToppings(_toppings);
    }

    public interface IToppings
    {
        double Cost(double basePrice);
        bool Empty();
        IToppings Add(ITopping topping);
        IText SentenceJoined();
    }
}