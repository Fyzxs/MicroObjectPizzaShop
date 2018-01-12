using microObjectPizzaShop.Library;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas.Toppers
{
    public class Topping : ITopping
    {
        private const double RegularPercentage = .1;
        private const double MeatPercentage = .15;
        private const double PremiumPercentage = 32;
        public static readonly ITopping Mushroom = new Topping("Mushroom", RegularPercentage;
        public static readonly ITopping Mozzarella = new Topping("Mozzarella", RegularPercentage);
        public static readonly ITopping Olive = new Topping("Olive", RegularPercentage);
        public static readonly ITopping Pepperoni = new Topping("Pepperoni", MeatPercentage);
        public static readonly ITopping Bacon = new Topping("Bacon", MeatPercentage);
        public static readonly ITopping Ham = new Topping("Ham", MeatPercentage);
        public static readonly ITopping RoastedGarlic = new Topping("Roasted Garlic", PremiumPercentage);
        public static readonly ITopping SunDriedTomato = new Topping("Sun Dried Tomato", PremiumPercentage);
        public static readonly ITopping FetaCheese = new Topping("Feta Cheese", PremiumPercentage);

        private readonly string _name;
        private readonly double _percentage;

        private Topping(string name, double percentage)
        {
            _name = name;
            _percentage = percentage;
        }

        public Money Cost(Money pizzaCost) => pizzaCost % _percentage;
        public IText Name() => new TextOf(_name);
    }
    public interface ITopping
    {
        Money Cost(Money pizzaCost);
        IText Name();
    }
}