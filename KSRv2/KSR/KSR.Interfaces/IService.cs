using KSR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Interfaces
{
    /// <summary>
    /// Service interface.
    /// </summary>
    /// <typeparam name="T">Generalized type.</typeparam>
    public interface IService<T>
    {
        /// <summary>
        /// Registration of new product.
        /// </summary>
        /// <param name="product">Product to register.</param>
        void Register(T product);
        /// <summary>
        /// Method for getting product by ID.
        /// </summary>
        /// <param name="id">Id of product.</param>
        /// <returns>Returns product.</returns>
        T GetProduct(int id);
        /// <summary>
        /// Method for getting product by name.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <returns>Returns product.</returns>
        T GetProductByName(string name);
        /// <summary>
        /// Update product method.
        /// </summary>
        /// <param name="product">Product to update.</param>
        /// <returns>true/false</returns>
        bool Update(T product);
        /// <summary>
        /// Unregister product method.
        /// </summary>
        /// <param name="id">Id of unregistering product.</param>
        void Unregister(int id);

    }
}
