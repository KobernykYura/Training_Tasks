using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR.Product;
using KSR.Exceptions;
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
            ValidationMethod(product);

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
            if (product != null)
                return product;
            else throw new ArgumentNullException($"No product {product} in database");
        }
        /// <summary>
        /// Get product by name.
        /// </summary>
        /// <param name="login">Product of important user.</param>
        /// <returns>Product with the same name.</returns>
        public AbstractProduct GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

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
            if (prod != null)
                DoUnregistr(id);
            else throw new IDException("Incorrect input of ID.");
        }


 
        /// <summary>
        /// Method of purchase of product.
        /// </summary>
        /// <param name="product">Purchased product.</param>
        /// <returns>Returns the purchase price.</returns>
        public double Buy(AbstractProduct product)
        {
            ValidationMethod(product);

            return DoBuy(product);
        }
        /// <summary>
        /// Method of purchasing several products.
        /// </summary>
        /// <param name="products">Set of purchased products.</param>
        /// <returns>Returns the purchase price.</returns>
        public double Buy(IEnumerable<AbstractProduct> products)
        {
            foreach (var item in products)
            {
                ValidationMethod(item);
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
                return _repository.GetBuy(product);
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
                return _repository.GetBuy(products);
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
        /// Product verification method.
        /// </summary>
        /// <param name="product">Product under test.</param>
        private static void ValidationMethod(AbstractProduct product)
        {
            //validation
            var results = new List<ValidationResult>();
            var context = new ValidationContext(product);
            if (!Validator.TryValidateObject(product, context, results, true))
            {
                string exceptionMessage = $"Product {product} validation exception:\n ";
                int i = 1;

                foreach (var error in results)
                {
                    exceptionMessage = string.Concat(exceptionMessage, $"{i++}) {error.ErrorMessage}\n");
                }
                throw new ValidationException(exceptionMessage);
            }
        }

    }
}
