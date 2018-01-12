using FluentAssertions;
using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas;
using microObjectPizzaShop.Pizzas.Description;
using microObjectPizzaShop.Pizzas.Toppers;
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
            IPizza pizza = PizzaType.Personal.Create();
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
            IPizza initial = PizzaType.Personal.Create();
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
            IPizza subject = PizzaType.Personal.Create();

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(9.00));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceWithTopping()
        {
            //Arrange
            IPizza initial = PizzaType.Personal.Create();
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
            IPizza initial = PizzaType.Personal.Create();
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
            IPizza initial = PizzaType.Personal.Create();
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
            IPizza initial = PizzaType.Personal.Create();
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
            IPizza initial = PizzaType.Personal.Create();
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
            IPizza subject = PizzaType.Large.Create();

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(18.00));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveLargePriceWithTopping()
        {
            //Arrange
            IPizza initial = PizzaType.Large.Create();
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
            IPizza initial = PizzaType.Personal.Create();
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
            IPizza pizza = PizzaType.Medium.Create();
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
            IPizza initial = PizzaType.Medium.Create();
            IPizza subject = initial.AddTopping(Topping.Bacon);

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(14.95));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveHalfCalzonePrice()
        {
            //Arrange
            ICalzone subject = CalzoneType.HalfCalzone.Create();

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(8));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayHalfCalzoneDescriptionWithNoToppings()
        {
            //Arrange
            ICalzone pizza = CalzoneType.HalfCalzone.Create();
            IDescription subject = pizza.Description();
            TestWriteString testWriteString = new TestWriteString();

            //Act
            subject.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("1/2 calzone");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveHalfCalzonePriceWithTopping()
        {
            //Arrange
            ICalzone initial = CalzoneType.HalfCalzone.Create();
            ICalzone subject = initial.AddTopping(Topping.Mozzarella);

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(8.80));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveFullCalzonePrice()
        {
            //Arrange
            ICalzone subject = CalzoneType.FullCalzone.Create();

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(14));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayFullCalzoneDescriptionWithNoToppings()
        {
            //Arrange
            ICalzone pizza = CalzoneType.FullCalzone.Create();
            IDescription subject = pizza.Description();
            TestWriteString testWriteString = new TestWriteString();

            //Act
            subject.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Full calzone");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldHaveFullCalzonePriceWithTopping()
        {
            //Arrange
            ICalzone initial = CalzoneType.FullCalzone.Create();
            ICalzone subject = initial.AddTopping(Topping.Mozzarella);

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(15.40));
        }


        [TestMethod, TestCategory("unit")]
        public void ShouldProvidePriceAfterRemovedTopping()
        {
            //Arrange
            IPizza initial = PizzaType.Personal.Create();
            IPizza subject = initial
                .AddTopping(Topping.Bacon)
                .AddTopping(Topping.Mushroom)
                .RemoveTopping(Topping.Bacon);

            //Act
            Money actual = subject.Price();

            //Assert
            actual.Should().Be(new Money(9.90));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldResizeFromPersonalToMedium()
        {
            //Arrange
            IPizza subject = PizzaType.Personal.Create();

            //Act
            IPizza actual = subject.As(PizzaType.Medium);

            //Assert
            actual.Should().BeOfType<MediumPizza>();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldMaintainToppingsAfterResizeFromPersonalToMedium()
        {
            //Arrange
            IPizza initial = PizzaType.Personal.Create().AddTopping(Topping.Mushroom);
            IPizza subject = initial.As(PizzaType.Medium);
            TestWriteString testWriteString = new TestWriteString();
            IDescription actual = subject.Description();
            //Act
            actual.Into(testWriteString);

            //Assert
            testWriteString.AssertValueIs("Medium pizza with Mushroom");
        }

    }
}