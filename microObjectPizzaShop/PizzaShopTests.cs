using FluentAssertions;
using microObjectPizzaShop.Library;
using microObjectPizzaShop.Library.Texts;
using microObjectPizzaShop.Pizza;
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
            TestWriteString testWriteString = new TestWriteString();

            //Act
            actual.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Personal pizza");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescriptionWithTopping()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
            IPizza pizza = initial.AddTopping(new Topping(new TextOf("SomeTopping"), .1));
            IDescription actual = pizza.Description();
            TestWriteString testWriteString = new TestWriteString();

            //Act
            actual.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Personal pizza with SomeTopping");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceWithNoTopping()
        {
            //Arrange
            IPizza subject = new PersonalPizza();

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(9.00));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceWithTopping()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
            IPizza subject = initial.AddTopping(new Topping(new TextOf("SomeTopping"), .1));

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(9.90));

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
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(10.80));

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
            TestWriteString testWriteString = new TestWriteString();

            //Act
            actual.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Personal pizza with SomeTopping and OtherTopping");
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
            TestWriteString testWriteString = new TestWriteString();

            //Act
            actual.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Personal pizza with SomeTopping, OtherTopping and Delicious");
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
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(11.25));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveFamilyPizzaPriceWithNoTopping()
        {
            //Arrange
            IPizza subject = new FamilyPizza();

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(18.00));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveFamilyPriceWithTopping()
        {
            //Arrange
            IPizza initial = new FamilyPizza();
            IPizza subject = initial.AddTopping(new Topping(new TextOf("SomeTopping"), .15));

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(20.70));
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayFamilyDescriptionWithNoToppings()
        {
            //Arrange
            IPizza pizza = new FamilyPizza();
            IDescription subject = pizza.Description();
            TestWriteString testWriteString = new TestWriteString();

            //Act
            subject.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Family pizza");
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldHaveImmutableToppings()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
            IPizza second = initial.AddTopping(new Topping(new TextOf("NonMeat"), .1));

            //Act
            Money initialPrice = initial.Price();
            Money secondPrice = second.Price();

            //Assert
            initialPrice.Should().NotBe(secondPrice);
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

        public Money Cost(Money pizzaCost) => pizzaCost % _percent;
        public IText Name() => _name;
    }

    public interface ITopping
    {
        Money Cost(Money pizzaCost);
        IText Name();
    }

    public interface IPizza
    {
        IDescription Description();
        Money Price();
        IPizza AddTopping(ITopping topping);
    }

    public class FamilyPizza : PersonalPizza
    {
        public FamilyPizza() : this(new Toppings()) { }
        public FamilyPizza(IToppings toppings) : base(toppings) { }

        protected override IText Name() => new TextOf("Family");
        protected override Money BasePrice() => new Money(18);
        protected override IPizza NewPizza(IToppings toppings) => new FamilyPizza(toppings);
    }

    public class PersonalPizza : Pizza
    {
        public PersonalPizza() : this(new Toppings()) { }
        public PersonalPizza(IToppings toppings) : base(toppings) { }

        protected override IText Name() => new TextOf("Personal");
        protected override Money BasePrice() => new Money(9);
        protected override IPizza NewPizza(IToppings toppings) => new PersonalPizza(toppings);
    }

    public abstract class Pizza : IPizza
    {
        private readonly IToppings _toppings;

        protected Pizza(IToppings toppings) => _toppings = toppings;

        public IDescription Description() => new PizzaDescription(Name(), _toppings);

        public IPizza AddTopping(ITopping topping) => NewPizza(_toppings.Add(topping));

        public Money Price() => BasePrice() + _toppings.Cost(BasePrice());

        protected abstract IPizza NewPizza(IToppings toppings);
        protected abstract IText Name();
        protected abstract Money BasePrice();
    }

    public class Toppings : IToppings
    {
        private readonly List<ITopping> _toppings;

        public Toppings() : this(new List<ITopping>()) { }

        public Toppings(List<ITopping> toppings) => _toppings = toppings;

        public Money Cost(Money basePrice)
        {
            Money result = new Money(0);
            foreach (ITopping topping in _toppings)
            {
                result += topping.Cost(basePrice);
            }
            return result;
        }

        public bool Empty() => !_toppings.Any();
        public IToppings Add(ITopping topping)
        {
            List<ITopping> toppings = new List<ITopping>();
            toppings.AddRange(_toppings);
            toppings.Add(topping);
            return new Toppings(toppings);
        }

        public IText Joined() => new SentenceJoinToppings(_toppings);
    }

    public interface IToppings
    {
        Money Cost(Money basePrice);
        bool Empty();
        IToppings Add(ITopping topping);
        IText Joined();
    }
}