using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace microObjectPizzaShop
{
    [TestClass]
    public class PizzaShopTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldHavePizza()
        {
            new Pizza();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldImplementIPizza()
        {
            IPizza pizz = new Pizza();
        }
    }

    public interface IPizza { }

    public class Pizza : IPizza { }
}
