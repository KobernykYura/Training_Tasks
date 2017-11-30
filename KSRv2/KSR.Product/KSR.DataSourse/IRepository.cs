using KSR.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.DataSourse
{
    public interface IRepository<T> where T : AbstractProduct
    {
        bool Update(T product);
        void Register(T product);
        void Unregister(int id);

        T GetProduct(int id);
        T GetProductByName(string name);
        IEnumerable<T> GetShopList();

        double GetBuy(T product);
        double GetBuy(IEnumerable<T> products);
    }
}
