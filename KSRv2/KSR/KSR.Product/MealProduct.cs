using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Product
{
    /// <summary>
    /// MealProduct class.
    /// </summary>
    public class MealProduct : AbstractGood
    {
        /// <summary>
        /// Date of product expiration.
        /// </summary>
        public DateTime ShelfLife { get; protected set; }

        /// <summary>
        /// Default value constructor .
        /// </summary>
        public MealProduct() : base()
        {

        }
        /// <summary>
        /// Constructor for name, amount, price.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="amount">Amount of products.</param>
        /// <param name="price">Price of one product</param>
        public MealProduct(string name, uint amount, decimal price) : base(name, amount, price)
        {
        }
        /// <summary>
        /// Constructor for name, amount, price, measure, value.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="amount">Amount of products.</param>
        /// <param name="price">Price of one product</param>
        /// <param name="measure">Measure of product's value.</param>
        /// <param name="value">Value of product.</param>
        public MealProduct(string name, uint amount, decimal price, double value, Type measure) : base(name, amount, price, measure, value)
        {

        }
        /// <summary>
        /// Constructor for name, amount, price, measure, value, release date.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="amount">Amount of products.</param>
        /// <param name="price">Price of one product</param>
        /// <param name="measure">Measure of product's value.</param>
        /// <param name="value">Value of product.</param>
        /// <param name="release">Date of creation.</param>
        public MealProduct(string name, uint amount, decimal price, double value, Type measure, DateTime release) : base(name, amount, price, measure, value, release)
        {

        }
        /// <summary>
        /// Constructor for name, amount, price, measure, value, release date.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="amount">Amount of products.</param>
        /// <param name="price">Price of one product</param>
        /// <param name="measure">Measure of product's value.</param>
        /// <param name="value">Value of product.</param>
        /// <param name="release">Date of creation.</param>
        /// <param name="lifetime">Date of product lifetime end.</param>
        public MealProduct(string name, uint amount, decimal price, double value, Type measure, DateTime release, DateTime lifetime) : base(name, amount, price,  measure, value, release)
        {
            this.ShelfLife = lifetime;
        }

    }
}
