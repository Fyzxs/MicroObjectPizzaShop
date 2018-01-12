using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas
{
    public class PizzaType : IPizzaType
    {
        public static readonly IPizzaType Large = new PizzaType("Large pizza", new Money(18));
        public static readonly IPizzaType Medium = new PizzaType("Medium pizza", new Money(13));
        public static readonly IPizzaType Personal = new PizzaType("Personal pizza", new Money(9));
        private readonly IText _type;
        private readonly Money _baseCost;

        private PizzaType(string type, Money baseCost) : this(new TextOf(type), baseCost) { }
        private PizzaType(IText type, Money baseCost)
        {
            _type = type;
            _baseCost = baseCost;
        }
        public virtual IPizza Create() => new Pizza(this, _baseCost);
        public virtual IPizza Create(IToppings toppings) => new Pizza(this, _baseCost, toppings);
        public string String() => _type.String();
    }
    public interface IPizzaType : IProductType
    {
        IPizza Create();
        IPizza Create(IToppings copy);
    }
}