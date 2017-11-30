using KSR.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.ValidatorHelper
{
    /// <summary>
    /// Class for throw exception on selected situation.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// The method throws an <see cref="ArgumentNullException"/> if the object is <see cref="null"/>.
        /// </summary>
        /// <param name="obj">inspected object.</param>
        /// <param name="message">exception message.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NullObject(object obj, string message = "Your object is null.")
        {
            if (obj == null)
                throw new ArgumentNullException(message);
        }
        /// <summary>
        /// The method throws an <see cref="ArgumentNullException"/> if the object is <see cref="null"/>.
        /// </summary>
        /// <param name="obj">inspected object.</param>
        /// <param name="exception">exception to call.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NullObject(object obj, Exception exception)
        {
            if (obj == null)
                throw exception;
        }
        /// <summary>
        /// The method throws an <see cref="ArgumentNullException"/> if the object is not <see cref="null"/>.
        /// </summary>
        /// <param name="obj">inspected object.</param>
        /// <param name="message">exception message.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NotNullObject(object obj, string message = "Your object is not null.")
        {
            if (obj != null)
                throw new ArgumentNullException(message);
        }
        /// <summary>
        /// The method throws an <see cref="InvalidCastException"/> if the object is not <see cref="T"/> type.
        /// </summary>
        /// <param name="obj">inspected object.</param>
        /// <param name="message">exception message.</param>
        /// <exception cref="InvalidCastException"></exception>
        public static void ObjectNotType<T>(object obj, string message = "Bad cast operation.") where T : class
        {
            if (!(obj is T))
                throw new InvalidCastException(message);
        }
        /// <summary>
        /// The method throws an <see cref="InvalidCastException"/> if the object is <see cref="T"/> type.
        /// </summary>
        /// <param name="obj">inspected object.</param>
        /// <param name="message">exception message.</param>
        /// <exception cref="InvalidCastException"></exception>
        public static void ObjectIsType<T>(object obj, string message = "Good cast operation.") where T : class
        {
            if (obj is T)
                throw new InvalidCastException(message);
        }
        /// <summary>
        /// The method throws an <see cref="ArgumentNullException"/> if the string is <see cref="null"/> or <see cref="Empty"/> or WhiteSpace.
        /// </summary>
        /// <param name="obj">inspected string.</param>
        /// <param name="message">exception message.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NullString(string str, string message = "Your string is null.")
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException("str",message);

            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentException(message, "str");
        }
        /// <summary>
        /// The method throws an <see cref="ArgumentNullException"/> if the string is not <see cref="null"/> or <see cref="Empty"/> or WhiteSpace.
        /// </summary>
        /// <param name="obj">inspected string.</param>
        /// <param name="message">exception message.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NotNullString(string str, string message = "Your string is not null.")
        {
            if (!string.IsNullOrEmpty(str))
                throw new ArgumentNullException("str", message);

            if (!string.IsNullOrWhiteSpace(str))
                throw new ArgumentException("str", message);
        }

        /// <summary>
        /// Product verification method.
        /// </summary>
        /// <param name="product">Product under test.</param>
        public static void ProductValidation(AbstractProduct product)
        {
            //validation
            var results = new List<ValidationResult>();
            var context = new ValidationContext(product);
            if (!Validator.TryValidateObject(product, context, results, true))
            {
                string exceptionMessage = $"Product {product} validation exception:\n ";
                int i = 1;

                foreach (var error in results)
                {
                    exceptionMessage = string.Concat(exceptionMessage, $"{i++}) {error.ErrorMessage}\n");
                }
                throw new ValidationException(exceptionMessage);
            }
        }

    }
}
