using System;

namespace MyCalculator
{
    /// <summary>
    /// Provides a method for check conversion the input <see cref="System.String" /> type to <see cref="System.Double" /> type.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strInput">Conversion value of <see cref="System.String" /> type.</param>
        /// <param name="result">Conversion result of <see cref="System.Double" /> type.</param>
        /// <returns>True if the value of the parameter <paramref name = "strInput" /> can be converted to <see cref = "System.Double" /> type; otherwise, false.</returns>
        public bool TryDouble(string strInput, out double result)
        {
            return double.TryParse(strInput, out result);
        }
        /// <summary>
        /// Returns a value of <see cref="System.Boolean"/> type depending on the parameter <paramref name="value"/>. 
        /// </summary>
        /// <param name="value">Parameter for check <see cref="System.Double"/> Min and Max borders.</param>
        /// <returns>Result of checking boders.</returns>
        public bool IsBordered(double value)
        {
            if (value > double.MaxValue || value < double.MinValue)
            {
                return true;
            }
            else return false;
        }
    }
}
