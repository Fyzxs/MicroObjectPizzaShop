using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas
{
    public class CalzoneType : ICalzoneType
    {
        public static readonly ICalzoneType HalfCalzone = new CalzoneType("1/2 calzone", new Money(8));
        public static readonly ICalzoneType FullCalzone = new CalzoneType("Full calzone", new Money(14));
        private readonly IText _type;
        private readonly Money _baseCost;

        private CalzoneType(string type, Money baseCost) : this(new TextOf(type), baseCost) { }
        private CalzoneType(IText type, Money baseCost)
        {
            _type = type;
            _baseCost = baseCost;
        }

        public ICalzone Create() => new Calzone(this, _baseCost);
        public ICalzone Create(IToppings toppings) => new Calzone(this, _baseCost, toppings);

        public string String() => _type.String();
    }

    public interface ICalzoneType : IProductType
    {
        ICalzone Create();
        ICalzone Create(IToppings copy);
    }
}