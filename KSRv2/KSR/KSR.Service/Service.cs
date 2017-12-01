using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR.Product;
using KSR.Interfaces;
using KSR.Exceptions;
using KSR.ValidatorHelper;
using System.ComponentModel.DataAnnotations;
using KSR.DataSourse;
using System.Data.SqlClient;

namespace KSR.Service
{
    /// <summary>
    /// Service class.
    /// </summary>
    public class Service : IService<AbstractGood> ,IBuyer<AbstractGood>
    {
        private readonly IRepository<AbstractGood> _repository;

        /// <summary>
        /// Constructor for setting products and basket repository.
        /// </summary>
        /// <param name="repository">Repository to connection.</param>
        public Service(IRepository<AbstractGood> repository)
        {
            // репозиторий для работы с продуктами.
            this._repository = repository;
        }


        /// <summary>
        /// Registration of new product.
        /// </summary>
        /// <param name="product">Product for registration.</param>
        public void Register(AbstractGood product)
        {
            ValidationHelper.NullObject(product);
            ValidationHelper.ProductValidation(product);

            _repository.Register(product);

        }
        /// <summary>
        /// Get product by id.
        /// </summary>
        /// <param name="id">Id of product.</param>
        /// <returns>Product that have this id.</returns>
        public AbstractGood GetProduct(int id)
        {
            AbstractGood product = _repository.GetProduct(id);

            ValidationHelper.NullObject(product, $"No product {product} in database");

            return product;
        }
        /// <summary>
        /// Get product by name.
        /// </summary>
        /// <param name="name">Product of important user.</param>
        /// <returns>Product with the same name.</returns>
        public AbstractGood GetProductByName(string name)
        {
            ValidationHelper.NullString(name);

            return _repository.GetProductByName(name);
        }
        /// <summary>
        /// Remove product from shop by id.
        /// </summary>
        /// <param name="id">ID of the product.</param>
        public void Unregister(int id)
        {
            AbstractGood prod =  _repository.GetProduct(id);

            ValidationHelper.NullObject(prod, new IDException("Incorrect input of ID."));

            _repository.Unregister(id);

        }

        /// <summary>
        /// Product update.
        /// </summary>
        /// <param name="product">Updated product.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Update(AbstractGood product)
        {
            ValidationHelper.NullObject(product);
            ValidationHelper.ProductValidation(product);

            return _repository.Update(product);
        }


        /// <summary>
        /// Method of purchase of product.
        /// </summary>
        /// <param name="product">Purchased product.</param>
        /// <returns>Returns the purchase price.</returns>
        public decimal Purchase(AbstractGood product)
        {
            ValidationHelper.NullObject(product);
            ValidationHelper.ProductValidation(product);

            var price = _repository.MakePurchase(product);
            var args = new PurchaseEventArgs(product.Name, price);

            this.WasBought?.Invoke(this, args);

            return price;
        }
        /// <summary>
        /// Method of purchasing several products.
        /// </summary>
        /// <param name="products">Set of purchased products.</param>
        /// <returns>Returns the purchase price.</returns>
        public decimal Purchase(IEnumerable<AbstractGood> products)
        {
            foreach (var product in products)
            {
                ValidationHelper.ProductValidation(product);
            }

            var price = _repository.MakePurchases(products);
            var count = products.Count();
            var args = new PurchaseEventArgs(count, price);

            this.WasBought?.Invoke(this, args);

            return price;
        }
        /// <summary>
        /// Get a list of purchased products.
        /// </summary>
        /// <returns>Returns the purchase price.</returns>
        public IEnumerable<AbstractGood> GetList()
        {
            return _repository.GetShopList();
        }
       
        /// <summary>
        /// EventHandler with <see cref="PurchaseEventArgs"/>. To inform a buyer about the completion of the purchase.
        /// </summary>
        public event EventHandler<PurchaseEventArgs> WasBought;
    }
}
