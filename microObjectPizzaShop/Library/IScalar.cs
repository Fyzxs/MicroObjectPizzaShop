namespace microObjectPizzaShop.Library {
    public interface IScalar<out T>
    {
        T Value();
    }
}