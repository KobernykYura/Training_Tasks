using KSR.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Service
{
    public interface IService<T> where T : class
    {
        void Register(T product);

        T GetProduct(int id);

        T GetProductByName(string name);

        void Unregister(int id);

    }
}
