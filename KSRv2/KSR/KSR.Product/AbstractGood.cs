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
    /// <summary>
    /// Base class for products. 
    /// It is important for us that the ID, Name, quantity, price, value, dimension, date of creation are in the class. 
    /// </summary>
    public abstract class AbstractGood : IValidatableObject, IEquatable<AbstractGood>
    {
        /// <summary>
        /// Product's ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of product. 
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Amount of product.
        /// </summary>
        public uint Amount { get; set; }

        /// <summary>
        /// Price for product.
        /// </summary>
        public decimal Price { get; protected set; }

        /// <summary>
        /// Value of product. Размер массы/объема
        /// </summary>
        public double Value { get; protected set; }

        /// <summary>
        /// Measure of product.
        /// </summary>
        public Type DimensionType { get; protected set; }

        /// <summary>
        /// Date of product creation.
        /// </summary>
        public DateTime CreationDate { get; protected set; }

        /// <summary>
        /// Default value constructor .
        /// </summary>
        public AbstractGood()
        {
            this.Name = "Product";
            this.Price = 0;
            this.Amount = 1;
            this.CreationDate = DateTime.Now;
        }
        /// <summary>
        /// Constructor for name, amount, price.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="amount">Amount of products.</param>
        /// <param name="price">Price of one product</param>
        public AbstractGood(string name, uint amount, decimal price)
        {
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
        }
        /// <summary>
        /// Constructor for name, amount, price, measure, value.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="amount">Amount of products.</param>
        /// <param name="price">Price of one product</param>
        /// <param name="measure">Measure of product's value.</param>
        /// <param name="value">Value of product.</param>
        public AbstractGood(string name, uint amount, decimal price, Type measure, double value) : this(name, amount, price)
        {
            this.DimensionType = measure;
            this.Value = value;
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
        public AbstractGood(string name, uint amount, decimal price, Type measure, double value, DateTime release) : this(name, amount, price, measure, value)
        {
            this.DimensionType = measure;
            this.CreationDate = release;
        }

        /// <summary>
        /// Overrided ToString.
        /// </summary>
        /// <returns>String of object.</returns>
        public override string ToString()
        {
            return "ID: " + ID + "   Name: " + Name;
        }
        /// <summary>
        /// Overrided Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true/false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            AbstractGood objAsProduct = obj as AbstractGood;
            if (objAsProduct == null) return false;
            else return Equals(objAsProduct);
        }
        /// <summary>
        /// Overrided HashCode.
        /// </summary>
        /// <returns>Returns the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Price.GetHashCode();
                return hash;
            }
        }
        /// <summary>
        /// Equals by ID.
        /// </summary>
        /// <param name="other">object to compare.</param>
        /// <returns>true/false</returns>
        public bool Equals(AbstractGood other)
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

            if (string.IsNullOrWhiteSpace(this.Name) || string.IsNullOrEmpty(this.Name))
                errors.Add(new ValidationResult("Name is empty."));

            if (this.Price < 0)
                errors.Add(new ValidationResult("Price can't be negative."));

            if (this.Value < 0)
                errors.Add(new ValidationResult("Value can't be negative."));

            return errors;
        }

    }
}
