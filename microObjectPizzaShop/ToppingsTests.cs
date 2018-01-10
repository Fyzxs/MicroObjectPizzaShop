using FluentAssertions;
using microObjectPizzaShop.Library;
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

        [TestMethod, TestCategory("unit")]
        public void ShouldRemoveImmutably()
        {
            //Arrange
            Toppings initial = new Toppings();
            IToppings multiple = initial.Add(Topping.Mushroom).Add(Topping.Mozzarella);

            //Act
            IToppings removed = multiple.Remove(Topping.Mushroom);

            //Assert
            removed.Cost(new Money(10)).Should().Be(new Money(1));
            multiple.Cost(new Money(10)).Should().Be(new Money(2));
        }
    }
}