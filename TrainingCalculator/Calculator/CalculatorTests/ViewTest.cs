using System;
using MyCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ViewTest
    {
        CalculatorMethods calculator = new CalculatorMethods();

        [TestMethod]
        public void Summation_ZeroZero_DoubleResult()
        {
            double value1 = 0;
            double value2 = 0;
            string name = "+";
            Func<double, double, double> function = calculator.Summation;

            View.Manipulation(value1, value2,name, function);
        }
        public void Summation_double_double()
        {
            double value1 = 0;
            double value2 = 0;
            string name = "+";
            Func<double, double, double> function = calculator.Summation;

            View.Manipulation(value1, value2, name, function);
        }
    }
}
