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
            IText actual = subject.Description();

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
            IText actual = subject.Description();

            //Assert
            actual.String().Should().Be("Personal pizza with SomeTopping");
        }
    }

    public interface IPizza
    {
        IPizza AddTopping(IText topping);
        IText Description();
    }

    public class Pizza : IPizza
    {
        private readonly IText _topping;

        public Pizza() : this(new EmptyText()) { }
        private Pizza(IText topping) => _topping = topping;

        public IPizza AddTopping(IText topping) => new Pizza(topping);
        public IText Description()
        {
            if (new EqualsText(_topping, new EmptyText()).Value()) return new TextOf("Personal pizza");
            return new FormatText(new TextOf("Personal pizza with {0}"), _topping);
        }
    }
}
