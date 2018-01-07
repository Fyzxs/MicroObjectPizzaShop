namespace microObjectPizzaShop.Library
{
    public abstract class Text : IText
    {
        public abstract string String();

        public bool IsEmpty() => String() == string.Empty;
    }

    public interface IText
    {
        string String();
        bool IsEmpty();
    }
}