using KSR.Product;
using KSR.Exceptions;
using System;
using System.Collections.Generic;
using Validator;

namespace KSR.DataSourse
{
    public class BasketRepository : IRepository<AbstractProduct>
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

        /// <summary>
        /// Get product by id.
        /// </summary>
        /// <param name="id">Id of product.</param>
        /// <returns>Returns the product by its id.</returns>
        public AbstractProduct GetProduct(int id)
        {
            return list.Find(i => i.ID == id);
        }
        /// <summary>
        /// Get product by name.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <returns>Returns the product by its name.</returns>
        public AbstractProduct GetProductByName(string name)
        {
            ValidationHelper.NullString(name);

            return list.Find(i => i.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
        /// <summary>
        /// Get a list of products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AbstractProduct> GetShopList()
        {
            return list;
        }
        /// <summary>
        /// Add product to list.
        /// </summary>
        /// <param name="product">Product to register.</param>
        public void Register(AbstractProduct product)
        {
            ValidationHelper.NullObject(product);

            list.Add(product);
        }
        /// <summary>
        /// Unregister this product.
        /// </summary>
        /// <param name="id">Id of product.</param>
        public void Unregister(int id)
        {
            list.Remove(GetProduct(id));
        }


        /// <summary>
        /// Buy all list of products.
        /// </summary>
        /// <returns>Returns the sum of all products.</returns>
        public double GetBuyAll()
        {
            double amount = 0;

            foreach (var item in list)
            {
                amount += item.Price;
            }

            list.Clear();
            list.TrimExcess();

            return amount;
        }
        /// <summary>
        /// Buy only one product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public double GetBuy(AbstractProduct product)
        {
            ValidationHelper.NullObject(product);

            var item = list.Find(i => i.ID == product.ID);

            if(!(list.Remove(product)))
                throw new RemoveException("No product in shop.");
            list.TrimExcess();

            return item.Price;
        }
        /// <summary>
        /// The method of buying a set of products.
        /// </summary>
        /// <param name="products">Purchased products.</param>
        /// <returns>The price of purchased products.</returns>
        public double GetBuy(IEnumerable<AbstractProduct> products)
        {
            double amount = 0;

            foreach (var item in products)
            {
                amount += GetProduct(item.ID).Price;

                if (!(list.Remove(item)))
                    throw new RemoveException("No product in shop.");
            }
            list.TrimExcess();

            return amount;
        }

    }
}
