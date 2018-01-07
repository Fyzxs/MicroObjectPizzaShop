using FluentAssertions;
using microObjectPizzaShop.Library;
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
            IPizza actual = subject.AddTopping(new TextOf("SomeTopping"));

            //Assert
            actual.Should().NotBeNull();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescription()
        {
            //Arrange
            IPizza subject = new Pizza();

            //Act
            Text actual = subject.Description();

            //Assert
            actual.String().Should().Be("Personal pizza");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayDescriptionWithTopping()
        {
            //Arrange
            IPizza initial = new Pizza();
            IPizza subject = initial.AddTopping(new TextOf("SomeTopping"));
            //Act
            Text actual = subject.Description();

            //Assert
            actual.String().Should().Be("Personal pizza with SomeTopping");
        }
    }
    public interface IPizza
    {
        IPizza AddTopping(Text topping);
        Text Description();
    }

    public class Pizza : IPizza
    {
        private static readonly Text PizzaType = new TextOf("Personal pizza");
        private static readonly Text Format = new TextOf("{0} with {1}");

        private readonly Text _topping;

        public Pizza() : this(new EmptyText()) { }
        private Pizza(Text topping) => _topping = topping;

        public IPizza AddTopping(Text topping) => new Pizza(topping);
        public Text Description()
        {
            if (_topping.IsEmpty()) return PizzaType;
            return new FormatText(Format, PizzaType, _topping);
        }
    }
}
