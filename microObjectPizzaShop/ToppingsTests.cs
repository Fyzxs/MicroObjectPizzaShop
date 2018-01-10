using FluentAssertions;
using microObjectPizzaShop.Pizzas.Toppers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace microObjectPizzaShop
{
    [TestClass]
    public class ToppingsTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldNotThrowExceptionRemovingNonAddedTopping()
        {
            //Arrange
            Toppings subject = new Toppings();

            //Act
            Action action = () => subject.Remove(Topping.Mushroom);

            //Assert
            action.ShouldNotThrow();
        }

    }
}