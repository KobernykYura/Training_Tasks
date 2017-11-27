using KSR.Common;
using System;
using System.Collections.Generic;

namespace KSR.DataSource
{
    public class BasketClass : IBasket
    {
        private List<IProduct> list = new List<IProduct>();

        public void Add(IProduct product)
        {
            list.Add(product);
        }

        public uint Buy() // покупка
        {
            uint cast = 0;

            for (int i = 0; i < list.Count; i++)
            {
                cast += list[i].Value;
            }

            return cast;
        }

        public IEnumerable<IProduct> GetList(IProduct product)
        {
            return list;
        }

        public void Remove(IProduct product)
        {
            try
            {
                list.Remove(product);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
        }
    }
}
