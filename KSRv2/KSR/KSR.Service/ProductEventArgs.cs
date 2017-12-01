using System;

namespace KSR.Service
{
    /// <summary>
    /// Purchase EventArgs.
    /// </summary>
    public class PurchaseEventArgs : EventArgs
    {
        /// <summary>
        /// Name of product.
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Price of purchace.
        /// </summary>
        public decimal Price { get; }
        /// <summary>
        /// Number of products.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Set arguments of name and price for product.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="price">Price of purchace.</param>
        public PurchaseEventArgs(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count">Number of products.</param>
        /// <param name="price">Price of purchace.</param>
        public PurchaseEventArgs(int count, decimal price)
        {
            this.Count = count;
            this.Price = price;
        }
    }
}