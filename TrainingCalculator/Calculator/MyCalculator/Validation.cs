using System;

namespace MyCalculator
{
    /// <summary>
    /// Provides a method for check conversion the input <see cref="System.String" /> type to <see cref="System.Double" /> type.
    /// </summary>
    class Validation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strInput">Conversion value of <see cref="System.String" /> type.</param>
        /// <param name="result">Conversion result of <see cref="System.Double" /> type.</param>
        /// <returns>true if the value of the parameter <paramref name = "strInput" /> can be converted to <see cref = "System.Double" /> type; otherwise, false.</returns>
        public bool TryDouble(string strInput, out double result)
        {
            return double.TryParse(strInput, out result);
        }
    }
}
