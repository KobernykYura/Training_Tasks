using System.Collections.Generic;
using KSR.Product;

namespace KSR.Service
{
    public interface IBuyer<T>
    {
        //void Add(T product);
        //void Add(IEnumerable<T> product);

        double Buy(T product);
        double Buy(IEnumerable<T> product);
        IEnumerable<T> GetList();

        //void Remove(T product);
        //void Remove(IEnumerable<T> product);
        //void RemoveAll();
    }
}