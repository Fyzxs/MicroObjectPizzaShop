using microObjectPizzaShop.Library;
using MicroObjectPizzaShop;
using MicroObjectPizzaShop.Library.Texts;
using System.Collections.Generic;

namespace microObjectPizzaShop.Pizza
{
    public class PizzaDescription : IDescription
    {
        private static readonly IText NoToppingsFormat = new TextOf("{0} pizza");
        private static readonly IText MultipleToppingsFormat = new TextOf("{0} pizza with {1}");

        private readonly IText _type;
        private readonly IToppings _toppings;

        public PizzaDescription(IText type, IToppings toppings)
        {
            _type = type;
            _toppings = toppings;
        }

        public void Into(IWriteString item)
        {
            if (ProcessedNoToppings(item)) return;

            ProcessToppingDescription(item);
        }

        private void ProcessToppingDescription(IWriteString item)
        {
            List<IText> texts = new List<IText>
            {
                _type,
                _toppings.Joined()
            };
            item.Write(new FormatText(MultipleToppingsFormat, texts.ToArray()).String());
        }

        private bool ProcessedNoToppings(IWriteString item)
        {
            if (!_toppings.Empty()) return false;

            item.Write(new FormatText(NoToppingsFormat, _type).String());
            return true;
        }
    }

    public interface IDescription
    {
        void Into(IWriteString item);
    }
}