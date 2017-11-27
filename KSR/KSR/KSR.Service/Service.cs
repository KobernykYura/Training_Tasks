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
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            this._repository = repository; // репозиторий для работы с продуктами.
        }

        public IProduct GetProduct(int id)
        {
           IProduct product = DoGetProductId(id); // проверка исключений
            if (product != null)
                return product;
            else throw new ArgumentNullException($"No product {product} in database");
        }

        public IProduct GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            IProduct product = DoGetProductName(name); // проверка исключний
            return product;
        }

        public void Register(IProduct product)
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

        public void Unregister(int id)
        {
            IProduct prod = _repository.GetProduct(id);
            if (prod != null)
                DoUnregistr(id);
            else throw new IDException("Incorrect input of ID.");
        }



        /// <summary>
        /// регистрация проверенного товара
        /// </summary>
        /// <param name="product"></param>
        private void DoRegistr(IProduct product)
        {
            try
            {
                _repository.Register(product);
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
                _repository.Unregister(id);
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
        private IProduct DoGetProductName(string name)
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


        private IProduct DoGetProductId(int id)
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
