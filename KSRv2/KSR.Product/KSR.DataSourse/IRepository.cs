using KSR.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.DataSourse
{
    public interface IRepository<T> where T : class
    {
        void Register(T product);

        T GetProduct(int id);

        T GetProductByName(string name);

        IEnumerable<T> GetShopList();

        void Unregister(int id);

        double GetBuyAll();
        double GetBuy(T product);
        double GetBuy(IEnumerable<T> products);
    }
}
