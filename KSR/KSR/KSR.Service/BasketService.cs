using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using KSR.Common;
using KSR.DataSource;
using KSR.Common.Exceptions;

namespace KSR.Service
{
    public class BasketService : IService
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Repository constructor.
        /// </summary>
        /// <param name="repository"></param>
        public BasketService(IRepository repository)
        {
            // репозиторий для работы с продуктами.
            this._repository = repository; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AbstractProduct GetProduct(int id)
        {
           AbstractProduct product = DoGetProductId(id); // проверка исключений
            if (product != null)
                return product;
            else throw new ArgumentNullException($"No product {product} in database");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AbstractProduct GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            AbstractProduct product = DoGetProductName(name); // проверка исключний
            return product;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void Register(AbstractProduct product)
        {
            //validation
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (GetProduct(product.ID) != null)
                throw new ValidationException($"Product with such ID is exist");

            if (GetProductByName(product.Name) != null)
                throw new ValidationException($"Product with such name currently exist");

            DoRegistr(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Unregister(int id)
        {
            AbstractProduct prod = DoGetProductId(id);
            if (prod != null)
                DoUnregistr(id);
            else throw new IDException("Incorrect input of ID.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint Buy()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IEnumerable<AbstractProduct> GetList(AbstractProduct product)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// регистрация проверенного товара
        /// </summary>
        /// <param name="product"></param>
        private void DoRegistr(AbstractProduct product)
        {
            try
            {
                _repository.Add(product);
            }
            catch (ConnectionException e)
            {
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }
        
        /// <summary>
        /// Дерегистрация товара
        /// </summary>
        /// <param name="id"></param>
        private void DoUnregistr(int id)
        {
            try
            {
                _repository.Remove(id);
            }
            catch (ConnectionException e)
            {
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }

        /// <summary>
        /// метод получения продукта из репозитория
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private AbstractProduct DoGetProductName(string name)
        {
            try
            {
                return _repository.GetProductByName(name);
            }
            catch (ConnectionException e)
            {
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }

        /// <summary>
        /// Method of checking product with ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private AbstractProduct DoGetProductId(int id)
        {
            try
            {
                return _repository.GetProduct(id);
            }
            catch (ConnectionException e)
            {
                throw new ConnectionException("Problems with connectiont to data source.", e);
            }
        }

    }
}
