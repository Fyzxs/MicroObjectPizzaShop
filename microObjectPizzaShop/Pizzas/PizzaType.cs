using microObjectPizzaShop.Library;
using microObjectPizzaShop.Pizzas.Description;
using microObjectPizzaShop.Pizzas.Toppers;
using MicroObjectPizzaShop.Library.Texts;
using System;

namespace microObjectPizzaShop.Pizzas
{
    public class PizzaType : IPizzaType
    {
        public static readonly IPizzaType Large = new LargePizzaType("Large pizza");
        public static readonly IPizzaType Medium = new MediumPizzaType("Medium pizza");
        public static readonly IPizzaType Personal = new PersonalPizzaType("Personal pizza");
        private readonly IText _type;

        private PizzaType(string type) : this(new TextOf(type)) { }
        private PizzaType(IText type) => _type = type;
        public virtual IPizza Create() { throw new Exception("Soon to be abstract"); }
        public virtual IPizza Create(IToppings copy) { throw new Exception("Soon to be abstract"); }

        public string String() => _type.String();

        private class PersonalPizzaType : PizzaType
        {
            public PersonalPizzaType(string type) : base(type) { }

            public override IPizza Create() => new PersonalPizza();
            public override IPizza Create(IToppings toppings) => new PersonalPizza(toppings);
        }
        private class MediumPizzaType : PizzaType
        {
            public MediumPizzaType(string type) : base(type) { }

            public override IPizza Create() => new MediumPizza();
            public override IPizza Create(IToppings toppings) => new MediumPizza(toppings);
        }
        private class LargePizzaType : PizzaType
        {
            public LargePizzaType(string type) : base(type) { }

            public override IPizza Create() => new LargePizza();
            public override IPizza Create(IToppings toppings) => new LargePizza(toppings);
        }
    }

    public abstract class CalzoneType : ICalzoneType
    {
        public static readonly ICalzoneType HalfCalzone = new HalfCalzoneType("1/2 calzone");
        public static readonly ICalzoneType FullCalzone = new FullCalzoneType("Full calzone");
        private readonly IText _type;

        private CalzoneType(string type) : this(new TextOf(type)) { }
        private CalzoneType(IText type) => _type = type;
        public abstract ICalzone Create();
        public abstract ICalzone Create(IToppings copy);

        public string String() => _type.String();

        private class HalfCalzoneType : CalzoneType
        {
            public HalfCalzoneType(string type) : base(type) { }

            public override ICalzone Create() => new HalfCalzone();
            public override ICalzone Create(IToppings toppings) => new HalfCalzone(toppings);
        }
        private class FullCalzoneType : CalzoneType
        {
            public FullCalzoneType(string type) : base(type) { }

            public override ICalzone Create() => new FullCalzone();
            public override ICalzone Create(IToppings toppings) => new FullCalzone(toppings);
        }
    }
    public interface ICalzoneType : IProductType
    {
        ICalzone Create();
        ICalzone Create(IToppings copy);
    }


    public interface ICalzone
    {
        IDescription Description();
        Money Price();
        ICalzone AddTopping(ITopping topping);
        ICalzone RemoveTopping(ITopping topping);
        ICalzone As(ICalzoneType calzoneType);
    }
}