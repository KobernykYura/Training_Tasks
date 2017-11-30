using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR.Product;
using KSR.Exceptions;
using KSR.ValidatorHelper;
using System.ComponentModel.DataAnnotations;
using KSR.DataSourse;

namespace KSR.Service
{
    public class Service : IService<AbstractProduct> ,IBuyer<AbstractProduct>
    {
        private readonly IRepository<AbstractProduct> _repository;

        /// <summary>
        /// Constructor for setting products and basket repository.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="basket"></param>
        public Service(IRepository<AbstractProduct> repository)
        {
            // репозиторий для работы с продуктами.
            this._repository = repository;
        }


        /// <summary>
        /// Registration of new product.
        /// </summary>
        /// <param name="product">Product for registration.</param>
        public void Register(AbstractProduct product)
        {
            ValidationHelper.ProductValidation(product);

            DoRegistr(product);
        }
        /// <summary>
        /// Get product by id.
        /// </summary>
        /// <param name="id">Id of product.</param>
        /// <returns>Product that have this id.</returns>
        public AbstractProduct GetProduct(int id)
        {
            AbstractProduct product = DoGetProductId(id); // проверка исключений
            
            ValidationHelper.NullObject(product, $"No product {product} in database");

            return product;
        }
        /// <summary>
        /// Get product by name.
        /// </summary>
        /// <param name="login">Product of important user.</param>
        /// <returns>Product with the same name.</returns>
        public AbstractProduct GetProductByName(string name)
        {
            ValidationHelper.NullString(name);

            AbstractProduct product = DoGetProductName(name); // проверка исключний
            return product;
        }
        /// <summary>
        /// Remove product from shop by id.
        /// </summary>
        /// <param name="id">ID of the product.</param>
        public void Unregister(int id)
        {
            AbstractProduct prod = DoGetProductId(id);

            ValidationHelper.NullObject(prod, new IDException("Incorrect input of ID."));

            DoUnregistr(id);
        }
        /// <summary>
        /// Method of purchase of product.
        /// </summary>
        /// <param name="product">Purchased product.</param>
        /// <returns>Returns the purchase price.</returns>
        public double Buy(AbstractProduct product)
        {
            ValidationHelper.ProductValidation(product);
            
            return DoBuy(product);
        }
        /// <summary>
        /// Method of purchasing several products.
        /// </summary>
        /// <param name="products">Set of purchased products.</param>
        /// <returns>Returns the purchase price.</returns>
        public double Buy(IEnumerable<AbstractProduct> products)
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
        public IEnumerable<AbstractProduct> GetList()
        {
            try
            {
                return _repository.GetShopList();
            }
            catch (ConnectionException e)
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
        private double DoBuy(AbstractProduct product)
        {
            try
            {
                var price = _repository.GetBuy(product);
                this.WasBought?.Invoke(this, new ProductEventArgs(product.Name, price));

                return price;
            }
            catch (ConnectionException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
            catch (RemoveException e)
            {
                // запись в лог
                throw new ConnectionException("No such product in source.", e);
            }
        }
        /// <summary>
        /// Purchase the selected products.
        /// </summary>
        /// <param name="products">Selected products.</param>
        /// <returns>Returns the purchase price.</returns>
        private double DoBuy(IEnumerable<AbstractProduct> products)
        {
            try
            {
                var price = _repository.GetBuy(products);
                var count = products.Count();

                this.WasBought?.Invoke(this, new ProductEventArgs(count, price));

                return price;
            }
            catch (ConnectionException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e); 
            }
        }
        /// <summary>
        /// Registration of the checked product.
        /// </summary>
        /// <param name="product">The resulting product.</param>
        private void DoRegistr(AbstractProduct product)
        {
            try
            {
                _repository.Register(product);
            }
            catch (ConnectionException e)
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
            catch (ConnectionException e)
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
        private AbstractProduct DoGetProductName(string name)
        {
            try
            {
                return _repository.GetProductByName(name);
            }
            catch (ConnectionException e)
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
        private AbstractProduct DoGetProductId(int id)
        {
            try
            {
                return _repository.GetProduct(id);
            }
            catch (ConnectionException e)
            {
                // запись в лог
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }

        /// <summary>
        /// EventHandler with <see cref="ProductEventArgs"/>. To inform a buyer about the completion of the purchase.
        /// </summary>
        public event EventHandler<ProductEventArgs> WasBought;
    }
}
