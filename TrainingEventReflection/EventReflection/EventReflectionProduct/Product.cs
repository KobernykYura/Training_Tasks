using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReflection.Products
{
    public class Product
    {
        /// <summary>
        /// Price fild.
        /// </summary>
        private decimal _price;

        /// <summary>
        /// Name property.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Price property with invocation of event.
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPriceChanged(new PriceChangedEventArgs(value)); // after 
            }
        }

        public Product()
        {
            this.Name = "Product";
        }
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Get-fixed products list.
        /// </summary>
        /// <returns></returns>
        public static List<Product> ProductList()
        {
            return new List<Product>()
            {
                new Product("Milk",100),
                new Product("Soap", 50),
                new Product("Bread", 70),
                new Product("Wather", 40)
            };

        }

        /// <summary>
        /// Event of changed price.
        /// </summary>
        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        /// <summary>
        /// Invocation of changed price event.
        /// </summary>
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }
        
    }
}
