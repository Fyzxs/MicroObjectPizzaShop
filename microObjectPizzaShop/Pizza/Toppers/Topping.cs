using microObjectPizzaShop.Library;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizza.Toppers
{
    public abstract class Topping : ITopping
    {
        public static readonly ITopping Mushroom = new RegularTopping("Mushroom");
        public static readonly ITopping Mozzarella = new RegularTopping("Mozzarella");
        public static readonly ITopping Olive = new RegularTopping("Olive");
        public static readonly ITopping Pepperoni = new MeatTopping("Pepperoni");
        public static readonly ITopping Bacon = new MeatTopping("Bacon");
        public static readonly ITopping Ham = new MeatTopping("Ham");

        private readonly IText _name;

        protected Topping(IText name) => _name = name;

        public Money Cost(Money pizzaCost) => pizzaCost % PercentCost();
        public IText Name() => _name;//TODO: Smelly - encapsulation violation
        protected abstract double PercentCost();

        private class RegularTopping : Topping
        {
            public RegularTopping(string name) : base(new TextOf(name)) { }
            protected override double PercentCost() => .1;
        }
        private class MeatTopping : Topping
        {
            public MeatTopping(string name) : base(new TextOf(name)) { }
            protected override double PercentCost() => .15;
        }
    }
    public interface ITopping
    {
        Money Cost(Money pizzaCost);
        IText Name();
    }
}