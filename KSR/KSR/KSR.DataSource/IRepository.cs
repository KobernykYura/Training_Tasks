using KSR.Common;
using System.Collections.Generic;

namespace KSR.DataSource
{
    public interface IRepository
    {
        void Add(AbstractProduct product);

        AbstractProduct GetProduct(int id);

        AbstractProduct GetProductByName(string name);

        uint GetPrice();

        IEnumerable<AbstractProduct> GetShopList(AbstractProduct product);

        void Remove(int id);
    }
}