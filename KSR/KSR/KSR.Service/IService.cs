using KSR.Common;

namespace KSR.Service
{
    public interface IService
    {
        void Register(IProduct product);

        IProduct GetProduct(int id);

        IProduct GetProductByName(string name);

        void Unregister(int id);
    }
}
