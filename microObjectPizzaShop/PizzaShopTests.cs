using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace microObjectPizzaShop
{
    [TestClass]
    public class PizzaShopTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldImplementIPizza()
        {
            IPizza pizza = new Pizza();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldAddTopping()
        {
            //Arrange
            IPizza pizza = new Pizza();

            //Act
            IPizza newPizza = pizza.AddTopping("SomeTopping");

            //Assert
        }
    }

    public interface IPizza
    {
        IPizza AddTopping(string topping);
    }

    public class Pizza : IPizza
    {
        public IPizza AddTopping(string topping) => new Pizza();
    }
}
