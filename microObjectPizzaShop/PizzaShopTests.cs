using FluentAssertions;
using microObjectPizzaShop;
using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizza;
using microObjectPizzaShop.Pizza.Description;
using microObjectPizzaShop.Pizza.Toppers;
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
        public void ShouldHaveLargePizzaPriceWithNoTopping()
        {
            //Arrange
            IPizza subject = new LargePizza();

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(18.00));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveLargePriceWithTopping()
        {
            //Arrange
            IPizza initial = new LargePizza();
            IPizza subject = initial.AddTopping(Topping.Bacon);

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(20.70));
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayLargeDescriptionWithNoToppings()
        {
            //Arrange
            IPizza pizza = new LargePizza();
            IDescription subject = pizza.Description();
            TestWriteString testWriteString = new TestWriteString();

            //Act
            subject.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Large pizza");
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

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayMediumDescriptionWithNoToppings()
        {
            //Arrange
            IPizza pizza = new MediumPizza();
            IDescription subject = pizza.Description();
            TestWriteString testWriteString = new TestWriteString();

            //Act
            subject.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Medium pizza");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveMediumPizzaPriceWithNoTopping()
        {
            //Arrange
            IPizza subject = new MediumPizza();

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(13.00));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveMediumPriceWithTopping()
        {
            //Arrange
            IPizza initial = new MediumPizza();
            IPizza subject = initial.AddTopping(Topping.Bacon);

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(14.95));
        }
    }
}