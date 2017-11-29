using KSR.Common;
using System;
using System.Collections.Generic;

namespace KSR.DataSource
{
    public class BasketRepository : IRepository
    {
        /// <summary>
        /// List of products for purchase
        /// </summary>
        private readonly List<AbstractProduct> list;

        /// <summary>
        /// Creation of Products list.
        /// </summary>
        public BasketRepository()
        {
            this.list = new List<AbstractProduct>();
        }

        // просмотр продукта по id
        public AbstractProduct GetProduct(int id)
        {
            try
            {
                return list.Find(i => i.ID == id);
            }
            catch (ArgumentNullException)
            {

                throw;
            }
        }

        /// <summary>
        /// Get product by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AbstractProduct GetProductByName(string name)
        {
            try
            {
                return list.Find(i => i.Name == name);
            }
            catch (ArgumentNullException)
            {

                throw;
            }

        }

        /// <summary>
        /// Buy list of products.
        /// </summary>
        /// <returns>Returns the sum of purchases</returns>
        public uint GetPrice() 
        {
            uint amount = 0;

            for (int i = 0; i < list.Count; i++)
            {
                amount += list[i].Price;
            }

            return amount;
        }

        // получить список купленного
        public IEnumerable<AbstractProduct> GetShopList(AbstractProduct product)
        {
            return list;
        }

        // добавить покупку
        public void Add(AbstractProduct product)
        {
            list.Add(product);
        }

        //убрать покупку
        public void Remove(int id)
        {
            try
            {
                list.Remove(GetProduct(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
