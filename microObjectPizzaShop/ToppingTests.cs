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
        public void ShouldCalculateCostAs32Percent()
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
            IPizza subject = new MediumPizza().AddTopping(Topping.RoastedGarlic);

            //Act
            IDescription actual = subject.Description();
            TestWriteString intoer = new TestWriteString();
            actual.Into(intoer);

            //Assert
            intoer.AssertValueIs("Medium pizza with Roasted Garlic");
        }

    }

}