using KSR.Product;
using KSR.Exceptions;
using System;
using System.Collections.Generic;
using KSR.ValidatorHelper;
using KSR.Interfaces;

namespace KSR.DataSourse
{
    /// <summary>
    /// Shop repository.
    /// </summary>
    public class ShopRepository : IRepository<AbstractGood>
    {
        private int count;

        /// <summary>
        /// List of products for purchase
        /// </summary>
        private readonly Dictionary<int, AbstractGood> list;

        /// <summary>
        /// Creation of Products list.
        /// </summary>
        public ShopRepository()
        {
            this.list = new Dictionary<int, AbstractGood>();
            count = int.MinValue;
        }

        /// <summary>
        /// Get product by id.
        /// </summary>
        /// <param name="id">Id of product.</param>
        /// <returns>Returns the product by its id.</returns>
        public AbstractGood GetProduct(int id)
        {
            AbstractGood prod = null;

            list.TryGetValue(id, out prod);

            return prod;
        }
        /// <summary>
        /// Get product by name.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <returns>Returns the product by its name.</returns>
        public AbstractGood GetProductByName(string name)
        {
            ValidationHelper.NullString(name);

            var values = list.Values;
            AbstractGood prod = null;

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
        public IEnumerable<AbstractGood> GetShopList()
        {
            return list.Values;
        }
        /// <summary>
        /// Update product in list.
        /// </summary>
        /// <param name="product">Updated product.</param>
        public bool Update(AbstractGood product)
        {
            ValidationHelper.NullObject(product);
            AbstractGood abstractProduct = null;

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
        public void Register(AbstractGood product)
        {
            ValidationHelper.NullObject(product);
            ValidationHelper.ProductValidation(product);

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
        public decimal MakePurchase(AbstractGood product)
        {
            ValidationHelper.NullObject(product);

            AbstractGood prod = null;
            var isGet = list.TryGetValue(product.ID, out prod);

            if(!isGet)
                throw new IDException("No product in shop.");

            prod.Amount--;

            if (prod.Amount == 0)
            {
                list.Remove(prod.ID);
            }

            return prod.Price;
        }
        /// <summary>
        /// The method of buying a set of products.
        /// </summary>
        /// <param name="products">Purchased products.</param>
        /// <returns>The price of purchased products.</returns>
        public decimal MakePurchases(IEnumerable<AbstractGood> products)
        {
            foreach (var product in products)
            {
                ValidationHelper.NullObject(product);
            }

            decimal price = 0;
            int amount = 0;

            foreach (var item in products)
            {
                AbstractGood good = null;

                if (!(list.TryGetValue(item.ID, out good)))
                    throw new IDException("No such product with such id in shop.");

                price += GetProduct(item.ID).Price;

                list.Remove(item.ID);

                good.Amount--;
                amount++;
            }

            return price;
        }

    }
}
