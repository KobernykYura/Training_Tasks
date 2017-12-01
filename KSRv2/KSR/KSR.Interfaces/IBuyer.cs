using System.Collections.Generic;
using KSR.Product;

namespace KSR.Interfaces
{
    /// <summary>
    /// Interface of buyer.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="AbstractGood"/></typeparam>
    public interface IBuyer<T> where T : AbstractGood
    {
        /// <summary>
        /// Purchase one product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Price for this purchase.</returns>
        decimal Purchase(T product);
        /// <summary>
        /// Purchase many products.
        /// </summary>
        /// <param name="products"><see cref="IEnumerable{T}"/> of products.</param>
        /// <returns>Price for this purchase.</returns>
        decimal Purchase(IEnumerable<T> products);
        /// <summary>
        /// Get list of all goods in shop.
        /// </summary>
        /// <returns>List of available goods.</returns>
        IEnumerable<T> GetList();
    }
}