namespace MicroObjectPizzaShop.Library.Texts
{
    public abstract class Text : IText
    {
        public abstract string String();
    }

    public interface IText
    {
        string String();
    }
}