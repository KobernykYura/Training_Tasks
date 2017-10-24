using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Interfaces
{
    /// <summary>
    /// Interface of simple operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IMathable<T>
    {
        T Summation(T x, T y);
        T Subtraction(T x, T y);
        T Division(T x, T y);
        T Multiplication(T x, T y);
    }
}
