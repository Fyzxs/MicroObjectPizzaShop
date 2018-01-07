using FluentAssertions;
using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza;
using microObjectPizzaShop.Pizza.Toppers;
using MicroObjectPizzaShop.Library.Texts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            IPizza pizza = initial.AddTopping(Topping.Mozzarella);
            IDescription actual = pizza.Description();
            TestWriteString testWriteString = new TestWriteString();

            //Act
            actual.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Personal pizza with Mozzarella");
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
            IPizza subject = initial.AddTopping(Topping.Mozzarella);

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
                .AddTopping(Topping.Mushroom)
                .AddTopping(Topping.Mozzarella);

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
                .AddTopping(Topping.Mushroom)
                .AddTopping(Topping.Mozzarella);
            IDescription actual = pizza.Description();
            TestWriteString testWriteString = new TestWriteString();

            //Act
            actual.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Personal pizza with Mushroom and Mozzarella");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvideDescriptionWithThreeToppings()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
            IPizza pizza = initial
                .AddTopping(Topping.Mushroom)
                .AddTopping(Topping.Olive)
                .AddTopping(Topping.Mozzarella);
            IDescription actual = pizza.Description();
            TestWriteString testWriteString = new TestWriteString();

            //Act
            actual.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Personal pizza with Mushroom, Olive and Mozzarella");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceForMeatAndNonMeatTopping()
        {
            //Arrange
            IPizza initial = new PersonalPizza();
            IPizza subject = initial
                .AddTopping(Topping.Bacon)
                .AddTopping(Topping.Mushroom);

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
            IPizza subject = initial.AddTopping(Topping.Bacon);

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
            IPizza second = initial.AddTopping(Topping.Mushroom);

            //Act
            Money initialPrice = initial.Price();
            Money secondPrice = second.Price();

            //Assert
            initialPrice.Should().NotBe(secondPrice);
        }
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
}