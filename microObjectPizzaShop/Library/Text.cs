namespace microObjectPizzaShop.Library
{
    public abstract class Text
    {
        public abstract string String();

        public bool IsEmpty() => String() == string.Empty;
    }
}