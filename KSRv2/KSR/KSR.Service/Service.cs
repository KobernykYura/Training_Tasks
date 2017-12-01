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

            DoRegistr(product);
        }
        /// <summary>
        /// Get product by id.
        /// </summary>
        /// <param name="id">Id of product.</param>
        /// <returns>Product that have this id.</returns>
        public AbstractGood GetProduct(int id)
        {
            AbstractGood product = DoGetProductId(id); // проверка исключений
            
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

            AbstractGood product = DoGetProductName(name); // проверка исключний
            return product;
        }
        /// <summary>
        /// Remove product from shop by id.
        /// </summary>
        /// <param name="id">ID of the product.</param>
        public void Unregister(int id)
        {
            AbstractGood prod = DoGetProductId(id);

            ValidationHelper.NullObject(prod, new IDException("Incorrect input of ID."));

            DoUnregistr(id);
        }

        /// <summary>
        /// Product update.
        /// </summary>
        /// <param name="product">Updated product.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(AbstractGood product)
        {
            ValidationHelper.NullObject(product);
            ValidationHelper.ProductValidation(product);
            DoUpdate(product);
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
            
            return DoBuy(product);
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

            return DoBuy(products);
        }
        /// <summary>
        /// Get a list of purchased products.
        /// </summary>
        /// <returns>Returns the purchase price.</returns>
        public IEnumerable<AbstractGood> GetList()
        {
            try
            {
                return _repository.GetShopList();
            }
            catch (SqlException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }
        


        /// <summary>
        /// Purchase the selected product.
        /// </summary>
        /// <param name="product">Selected product.</param>
        /// <returns>Returns the purchase price.</returns>
        private decimal DoBuy(AbstractGood product)
        {
            try
            {
                var price = _repository.MakePurchase(product);
                this.WasBought?.Invoke(this, new PurchaseEventArgs(product.Name, price));

                return price;
            }
            catch (SqlException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
            
        }
        /// <summary>
        /// Purchase the selected products.
        /// </summary>
        /// <param name="products">Selected products.</param>
        /// <returns>Returns the purchase price.</returns>
        private decimal DoBuy(IEnumerable<AbstractGood> products)
        {
            try
            {
                var price = _repository.MakePurchases(products);
                var count = products.Count();

                this.WasBought?.Invoke(this, new PurchaseEventArgs(count, price));

                return price;
            }
            catch (SqlException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e); 
            }
        }
        /// <summary>
        /// Registration of the checked product.
        /// </summary>
        /// <param name="product">The resulting product.</param>
        private void DoRegistr(AbstractGood product)
        {
            try
            {
                _repository.Register(product);
            }
            catch (SqlException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }
        /// <summary>
        /// Deregistration of products.
        /// </summary>
        /// <param name="id">The resulting product id.</param>
        private void DoUnregistr(int id)
        {
            try
            {
                _repository.Unregister(id);
            }
            catch (SqlException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }
        /// <summary>
        /// Method of getting the product
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <returns>The resulting product</returns>
        private AbstractGood DoGetProductName(string name)
        {
            try
            {
                return _repository.GetProductByName(name);
            }
            catch (SqlException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }
        /// <summary>
        /// Method of checking product with ID.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <returns>The resulting product.</returns>
        private AbstractGood DoGetProductId(int id)
        {
            try
            {
                return _repository.GetProduct(id);
            }
            catch (SqlException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }

        /// <summary>
        /// Method of checking product with ID.
        /// </summary>
        /// <param name="product">Id of the product.</param>
        /// <returns>The resulting product.</returns>
        private bool DoUpdate(AbstractGood product)
        {
            try
            {
                return _repository.Update(product);
            }
            catch (SqlException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }

        /// <summary>
        /// EventHandler with <see cref="PurchaseEventArgs"/>. To inform a buyer about the completion of the purchase.
        /// </summary>
        public event EventHandler<PurchaseEventArgs> WasBought;
    }
}
