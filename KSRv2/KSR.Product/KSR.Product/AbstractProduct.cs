using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using KSR.ValidationAttributes;
using System.Runtime.CompilerServices;

namespace KSR.Product
{
    public abstract class AbstractProduct : IValidatableObject, IEquatable<AbstractProduct>
    {
        public int ID { get; private set; }

        /// <summary>
        /// Name of product. 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Price for product.
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// Value of product.
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Measure of product.
        /// </summary>
        public Type Measure { get; private set; }

        /// <summary>
        /// Date of product creation.
        /// </summary>
        public DateTime CreationDate { get; private set; }

        /// <summary>
        /// Date of product life time ends.
        /// </summary>
        public DateTime ExpiryDate { get; private set; }

        public AbstractProduct()
        {
            this.Name = "Product";
            this.Price = 0;
            this.Value = 0;
        }
        public AbstractProduct(string name, double value) : this()
        {
            this.Name = name;
            this.Value = value;
        }
        public AbstractProduct(string name, double value, double price) : this(name, value)
        {
            this.Price = price;
        }
        public AbstractProduct(string name, double value, double price, Type measure, DateTime release) : this(name, price, value)
        {
            this.Measure = measure;
            this.CreationDate = release;
        }
        public AbstractProduct(string name, double value, double price, Type measure, DateTime release, DateTime lifetime) : this( name,  price, value,  measure, release)
        {
            this.ExpiryDate = lifetime;
        }

        public override string ToString()
        {
            return "ID: " + ID + "   Name: " + Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            AbstractProduct objAsProduct = obj as AbstractProduct;
            if (objAsProduct == null) return false;
            else return Equals(objAsProduct);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public bool Equals(AbstractProduct other)
        {
            if (other == null) return false;
            return (this.ID.Equals(other.ID));
        }

        /// <summary>
        /// Method for model validation.
        /// </summary>
        /// <param name="validationContext">Validation context.</param>
        /// <returns>List of errors.</returns>
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Name))
                errors.Add(new ValidationResult("Name is empty."));

            if (this.Price < 0)
                errors.Add(new ValidationResult("Price can't be negative."));

            if (this.Value < 0)
                errors.Add(new ValidationResult("Value can't be negative."));

            if (this.CreationDate < this.ExpiryDate)
                errors.Add(new ValidationResult("The expiry date can't be less than the date of creation."));

            return errors;
        }

    }
}
