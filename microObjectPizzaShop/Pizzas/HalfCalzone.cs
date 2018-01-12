using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas
{
    public class HalfCalzone : Calzone
    {
        public HalfCalzone() : this(new Toppings()) { }
        public HalfCalzone(IToppings toppings) : base(toppings) { }

        protected override ICalzoneType Type() => CalzoneType.HalfCalzone;
        protected override Money BasePrice() => new Money(8);
    }
}