using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Product
{
    public class BulkProduct : AbstractProduct
    {

        /// <summary>
        /// Amount of product.
        /// </summary>
        public uint Amount { get; private set; }

        public BulkProduct() : base()
        {
            this.Amount = 0;
        }
        public BulkProduct(string name, double value, uint amount) : base(name, value)
        {
            this.Amount = amount;
        }
        public BulkProduct(string name, double value, uint amount, double price) : this(name, value, amount)
        {

        }
        public BulkProduct(string name, double value, uint amount, double price, Type measure, DateTime release) : this(name, price, amount, value)
        {

        }
        public BulkProduct(string name, double value, uint amount, double price, Type measure, DateTime release, DateTime lifetime) : this( name,  price, amount, value,  measure, release)
        {

        }

    }
}
