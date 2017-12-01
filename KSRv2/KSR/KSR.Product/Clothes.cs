using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Product
{
    /// <summary>
    /// Clothes class. Inherited from <see cref="AbstractGood"/>.
    /// </summary>
    public class Clothes : AbstractGood
    {
        /// <summary>
        /// Hight of clothes.
        /// </summary>
        public uint Height { get; protected set; }

        /// <summary>
        /// Width of clothes.
        /// </summary>
        public uint Width { get; protected set; }

        /// <summary>
        /// Matherial of clothes.
        /// </summary>
        public Type Material { get; protected set; }

        /// <summary>
        /// Default value constructor .
        /// </summary>
        public Clothes() : base()
        {

        }
        /// <summary>
        /// Constructor for name, amount, price.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="amount">Amount of products.</param>
        /// <param name="price">Price of one product</param>
        public Clothes(string name, uint amount, decimal price) : base(name, amount, price)
        {
        }
        /// <summary>
        /// Constructor for name, amount, price, measure, value.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="amount">Amount of products.</param>
        /// <param name="price">Price of one product</param>
        /// <param name="hight">Hight of this cloth.</param>
        /// <param name="width">Width of this cloth.</param>
        /// <param name="matherial">Material of this cloth.</param>
        public Clothes(string name, uint amount, decimal price, uint hight, uint width, Type matherial) : base(name, amount, price)
        {
            this.Height = hight;
            this.Width = width;
            this.Material = matherial;
        }
        /// <summary>
        /// Constructor for name, amount, price, measure, value.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="amount">Amount of products.</param>
        /// <param name="price">Price of one product</param>
        /// <param name="hight">Hight of this cloth.</param>
        /// <param name="width">Width of this cloth.</param>
        /// <param name="matherial">Material of this cloth.</param>
        /// <param name="release">Date of creation.</param>
        public Clothes(string name, uint amount, decimal price, uint hight, uint width, Type matherial, DateTime release) : this(name, amount, price, hight, width, matherial)
        {

        }

    }
}
