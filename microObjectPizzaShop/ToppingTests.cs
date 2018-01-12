using FluentAssertions;
using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;
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
    }

}