using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace microObjectPizzaShop
{
    [TestClass]
    public class PizzaShopTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldImplementIPizza()
        {
            IPizza subject = new Pizza();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldAddTopping()
        {
            //Arrange
            IPizza subject = new Pizza();

            //Act
            IPizza actual = subject.AddTopping("SomeTopping");

            //Assert
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescription()
        {
            //Arrange
            IPizza subject = new Pizza();

            //Act
            string actual = subject.Description();

            //Assert
            actual.Should().Be("Personal pizza");
        }
    }

    public interface IPizza
    {
        IPizza AddTopping(string topping);
        string Description();
    }

    public class Pizza : IPizza
    {
        public IPizza AddTopping(string topping) => new Pizza();
        public string Description() => "Personal pizza";
    }
}
