using KSR.Product;
using KSR.Exceptions;
using System;
using System.Collections.Generic;
using KSR.ValidatorHelper;

namespace KSR.DataSourse
{
    public class BasketRepository : IRepository<AbstractProduct>
    {
        private int count;

        /// <summary>
        /// List of products for purchase
        /// </summary>
        private readonly Dictionary<int, AbstractProduct> list;

        /// <summary>
        /// Creation of Products list.
        /// </summary>
        public BasketRepository()
        {
            this.list = new Dictionary<int, AbstractProduct>();
            count = int.MinValue;
        }

        /// <summary>
        /// Get product by id.
        /// </summary>
        /// <param name="id">Id of product.</param>
        /// <returns>Returns the product by its id.</returns>
        public AbstractProduct GetProduct(int id)
        {
            AbstractProduct prod = null;

            list.TryGetValue(id, out prod);

            return prod;
        }
        /// <summary>
        /// Get product by name.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <returns>Returns the product by its name.</returns>
        public AbstractProduct GetProductByName(string name)
        {
            ValidationHelper.NullString(name);

            var values = list.Values;
            AbstractProduct prod = null;

            foreach (var v in values)
            {
                if (v.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    prod = v;
                }
            }
            return prod;
        }
        /// <summary>
        /// Get a list of products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AbstractProduct> GetShopList()
        {
            return list.Values;
        }
        /// <summary>
        /// Update product in list.
        /// </summary>
        /// <param name="product">Updated product.</param>
        public bool Update(AbstractProduct product)
        {
            ValidationHelper.NullObject(product);
            AbstractProduct abstractProduct = null;

            bool contains = list.TryGetValue(product.ID, out abstractProduct);

            if (contains)
            {
                list.Remove(abstractProduct.ID);
                list.Add(product.ID,product);
            }
            return contains;
        }
        /// <summary>
        /// Add product to list.
        /// </summary>
        /// <param name="product">Product to register.</param>
        public void Register(AbstractProduct product)
        {
            ValidationHelper.NullObject(product);
            product.ID = count;
            list.Add(count++, product);
        }
        /// <summary>
        /// Unregister this product.
        /// </summary>
        /// <param name="id">Id of product.</param>
        public void Unregister(int id)
        {
            list.Remove(id);
        }


        /// <summary>
        /// Buy only one product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public double GetBuy(AbstractProduct product)
        {
            ValidationHelper.NullObject(product);

            AbstractProduct prod = null;
            var isGet = list.TryGetValue(product.ID, out prod);

            if(!isGet)
                throw new IDException("No product in shop.");

            list.Remove(prod.ID);

            return prod.Price;
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
                if (!(list.ContainsValue(item)))
                    throw new KeyNotFoundException("No such product in shop.");
            
                amount += GetProduct(item.ID).Price;

                if (!(list.Remove(item.ID)))
                    throw new RemoveException("No product in shop.");
            }

            return amount;
        }

    }
}
