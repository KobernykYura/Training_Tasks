using KSR.Common;
using System.Collections.Generic;

namespace KSR.Service
{
    public interface IService
    {
        void Register(AbstractProduct product);

        AbstractProduct GetProduct(int id);

        AbstractProduct GetProductByName(string name);

        uint Buy();

        IEnumerable<AbstractProduct> GetList(AbstractProduct product);

        void Unregister(int id);
    }
}
