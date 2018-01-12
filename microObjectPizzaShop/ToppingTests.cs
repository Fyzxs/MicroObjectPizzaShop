using FluentAssertions;
using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas;
using microObjectPizzaShop.Pizzas.Description;
using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace microObjectPizzaShop
{
    [TestClass]
    public class ToppingTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldRoastedGarlicCalculateCostAs32Percent()
        {
            //Arrange
            ITopping subject = Topping.RoastedGarlic;

            //Act
            Money actual = subject.Cost(new Money(1));

            //Assert
            actual.Should().Be(new Money(0.32));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeRoastedGarlic()
        {
            //Arrange
            IPizza subject = PizzaType.Medium.Create().AddTopping(Topping.RoastedGarlic);

            //Act
            IDescription actual = subject.Description();
            TestWriteString intoer = new TestWriteString();
            actual.Into(intoer);

            //Assert
            intoer.AssertValueIs("Medium pizza with Roasted Garlic");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldSunDriedTomatoCalculateCostAs32Percent()
        {
            //Arrange
            ITopping subject = Topping.SunDriedTomato;

            //Act
            Money actual = subject.Cost(new Money(1));

            //Assert
            actual.Should().Be(new Money(0.32));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeSunDriedTomato()
        {
            //Arrange
            IPizza subject = PizzaType.Medium.Create().AddTopping(Topping.SunDriedTomato);

            //Act
            IDescription actual = subject.Description();
            TestWriteString intoer = new TestWriteString();
            actual.Into(intoer);

            //Assert
            intoer.AssertValueIs("Medium pizza with Sun Dried Tomato");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldFetaCheeseCalculateCostAs32Percent()
        {
            //Arrange
            ITopping subject = Topping.FetaCheese;

            //Act
            Money actual = subject.Cost(new Money(1));

            //Assert
            actual.Should().Be(new Money(0.32));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFetaCheese()
        {
            //Arrange
            IPizza subject = PizzaType.Medium.Create().AddTopping(Topping.FetaCheese);

            //Act
            IDescription actual = subject.Description();
            TestWriteString intoer = new TestWriteString();
            actual.Into(intoer);

            //Assert
            intoer.AssertValueIs("Medium pizza with Feta Cheese");
        }

    }

}