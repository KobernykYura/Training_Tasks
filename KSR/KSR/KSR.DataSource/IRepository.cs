using KSR.Common;
using System.Collections.Generic;

namespace KSR.DataSource
{
    public interface IRepository
    {
        void Register(IProduct product);

        IProduct GetProduct(int id);

        IProduct GetProductByName(string name);

        uint Buy();

        IEnumerable<IProduct> GetList(IProduct product);

        void Unregister(int id);
    }
}