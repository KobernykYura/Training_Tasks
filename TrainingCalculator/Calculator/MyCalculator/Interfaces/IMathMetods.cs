using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Interfaces
{
    interface IMathMetods<T>
    {
        T Summation(T x, T y);
        T Subtraction(T x, T y);
        T Division(T x, T y);
        T Multiplication(T x, T y);
    }
}
