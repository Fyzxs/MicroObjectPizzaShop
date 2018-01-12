using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Toppers;

namespace microObjectPizzaShop.Pizzas
{
    public class FullCalzone : Calzone
    {
        public FullCalzone() : this(new Toppings()) { }
        public FullCalzone(IToppings toppings) : base(toppings) { }

        protected override ICalzoneType Type() => CalzoneType.FullCalzone;
        protected override Money BasePrice() => new Money(14);
    }
}