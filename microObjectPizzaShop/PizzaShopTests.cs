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
    }

    public interface IPizza { }

    public class Pizza : IPizza { }
}
