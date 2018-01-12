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
        public void ShouldHavePremiumTopping()
        {
            //Arrange
            Topping premium = new PremiumTopping("name here");


            //Act

            //Assert
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldCalculateCostAs32Percent()
        {
            //Arrange
            PremiumTopping subject = new PremiumTopping("blah");

            //Act
            Money actual = subject.Cost(new Money(1));

            //Assert
            actual.Should().Be(new Money(0.32));
        }
    }

    public class PremiumTopping : Topping
    {
        public PremiumTopping(string nameHere) : base(nameHere) { }

        protected override double PercentCost()
        {
            return .32;
        }
    }
}