using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Common
{
    /// <summary>
    /// Base Product for all products.
    /// </summary>
    public abstract class AbstractProduct
    {
        public int ID { get; private set; }
        // Name of product.
        public string Name { get; set; }
        // Price for product.
        public uint Price { get; private set; }
        // Value of measure.
        public uint Value { get; private set; }
        // Measure of product.
        public string Measure { get; set; }
        // Date of product creation.
        public DateTime ReleaseDate { get; set; }

        public AbstractProduct(string name, uint value, DateTime dateTime)
        {
            this.Name = name;
            this.Price = value;
            this.ReleaseDate = dateTime;
        }

        public AbstractProduct(string name, uint value, int id, DateTime dateTime) : this(name, value, dateTime)
        {
            this.ID = id;
        }

    }
}
