using microObjectPizzaShop.Library;
using MicroObjectPizzaShop.Library.Texts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace microObjectPizzaShop.Pizza.Toppers
{
    public class Toppings : IToppings
    {
        private readonly List<ITopping> _toppings;

        public Toppings() : this(new List<ITopping>()) { }

        public Toppings(List<ITopping> toppings) => _toppings = toppings;

        public Money Cost(Money basePrice)
        {
            //TODO: Smelly - Looping vs LINQ
            Money result = new Money(0);
            foreach (ITopping topping in _toppings)
            {
                result += topping.Cost(basePrice);
            }
            return result;
        }

        public bool Empty() => !_toppings.Any();
        public IToppings Add(ITopping topping)
        {
            List<ITopping> toppings = new List<ITopping>();
            toppings.AddRange(_toppings);
            toppings.Add(topping);
            return new Toppings(toppings);
        }

        public IText Joined() => new SentenceJoinToppings(this);

        public IEnumerator<ITopping> GetEnumerator() => _toppings.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public interface IToppings : IEnumerable<ITopping>
    {
        Money Cost(Money basePrice);
        bool Empty();
        IToppings Add(ITopping topping);
        IText Joined();
    }
}