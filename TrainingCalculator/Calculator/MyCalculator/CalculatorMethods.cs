using System;
using MyCalculator.Interfaces;

namespace MyCalculator
{
    /// <summary>
    /// Represents a class for performing sum, subtraction, and multiplication operations.
    /// </summary>
    public class CalculatorMethods : IMathMetods<double> 
    {
        /// <summary>
        /// Counts the summation of two values and outputs the result of the operation.
        /// </summary>
        /// <param name="x">A double precision floating-point number.</param>
        /// <param name="y">A double precision floating-point number.</param>
        /// <returns>The number <paramref name = "x" />, summed with <paramref name = "y" />.</returns>
        public double Summation(double x, double y)
        {
            return x + y;
        }
        /// <summary>
        /// Counts the subtraction of two values and outputs the result of the operation.
        /// </summary>
        /// <param name="x">A double precision floating-point number.</param>
        /// <param name="y">A double precision floating-point number.</param>
        /// <returns>The number <paramref name = "x" />, summed with <paramref name = "y" />.</returns>
        public double Subtraction(double x, double y)
        {
            return x - y;
        }
        /// <summary>
        /// Counts the division of two values and outputs the result of the operation.
        /// </summary>
        /// <param name="x">A double precision floating-point number.</param>
        /// <param name="y">A double precision floating-point number. Can not be zero.</param>
        /// <returns>The number <paramref name = "x" />, divided with <paramref name = "y" />.</returns>
        public double Division(double x, double y)
        {
            return x / y;
        }
        /// <summary>
        /// Counts the multiplication of two values and outputs the result of the operation.
        /// </summary>
        /// <param name="x">A double precision floating-point number.</param>
        /// <param name="y">A double precision floating-point number.</param>
        /// <returns>The number <paramref name = "x" />, summed with <paramref name = "y" />.</returns>
        public double Multiplication(double x, double y)
        {
            return x * y;
        }
    }
}
