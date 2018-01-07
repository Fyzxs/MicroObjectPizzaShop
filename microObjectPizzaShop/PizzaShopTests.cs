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
    }

    public class Pizza { }
}
