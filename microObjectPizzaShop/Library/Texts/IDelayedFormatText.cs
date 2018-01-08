using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Library.Texts {
    public interface IDelayedFormatText : IText
    {
        IDelayedFormatText Add(IText arg);
    }
}