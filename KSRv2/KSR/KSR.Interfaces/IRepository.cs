using KSR.Product;
using System.Collections.Generic;

namespace KSR.Interfaces
{
    /// <summary>
    /// Repository interface.
    /// </summary>
    /// <typeparam name="T">Generalized type.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Update product method.
        /// </summary>
        /// <param name="product">Product to update.</param>
        /// <returns>true/false</returns>
        bool Update(T product);
        /// <summary>
        /// Registration of new product.
        /// </summary>
        /// <param name="product">Product to register.</param>
        void Register(T product);
        /// <summary>
        /// Unregister product method.
        /// </summary>
        /// <param name="id">Id of unregistering product.</param>
        void Unregister(int id);

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
        /// Full list of avaliable goods.
        /// </summary>
        /// <returns>Returns list of all goods.</returns>
        IEnumerable<T> GetShopList();

        /// <summary>
        /// The method of buying one product.
        /// </summary>
        /// <param name="product">Purchased product.</param>
        /// <returns>Returns the purchase price.</returns>
        decimal MakePurchase(T product);
        /// <summary>
        /// Method of buying several goods.
        /// </summary>
        /// <param name="products">Purchased products.</param>
        /// <returns>Returns the purchase price.</returns>
        decimal MakePurchases(IEnumerable<T> products);
    }
}
