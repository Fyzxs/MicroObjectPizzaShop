using microObjectPizzaShop.Library;
using MicroObjectPizzaShop;

namespace microObjectPizzaShop.Pizza {
    public interface IDescription
    {
        void Into(IWriteString item);
    }
}