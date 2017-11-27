using KSR.Common;
using System.Collections;
using System.Collections.Generic;

namespace KSR.DataSource
{
    public interface IBasket
    {
        void Add(IProduct product);

        void Remove(IProduct product);

        IEnumerable<IProduct> GetList(IProduct product);

        uint Buy();
    }
}