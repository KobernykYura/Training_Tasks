using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator
{
    /// <summary>
    /// Class of view logic.
    /// </summary>
    public class ViewLogic
    {
        /// <summary>
        /// Method for analysis entered operation.
        /// </summary>
        /// <param name="arg">Name of our operation. Parameter is <see cref="System.String"/> type.</param>
        /// <param name="x">Prarmeter of <see cref="System.Double" /> type. Value for calculation.</param>
        /// <param name="y">Prarmeter of <see cref="System.Double" /> type. Value for calculation.</param>
        /// <param name="mean">Output parameter of operation result.</param>
        /// <returns>Returns condition if entered key is good.</returns>
        public static bool SwitchCase(string arg, double x , double y, out double mean)
        {
            CalculatorMethods calculator = new CalculatorMethods();
            bool choice = false; //----This is condition of right enter of "arg" parameter

            //----Checking arg on case
            switch (arg)
            {
                case "+":
                    mean = Manipulation(x, y, calculator.Summation);
                    choice = !double.IsInfinity(mean);
                    break;
                case "*":
                    mean = Manipulation(x, y, calculator.Multiplication);
                    choice = !double.IsInfinity(mean);
                    break;
                case "-":
                    mean = Manipulation(x, y, calculator.Subtraction);
                    choice = !double.IsInfinity(mean);
                    break;
                case "/":
                    if (y == 0)
                    {
                        Console.WriteLine("You can not divide by zero.");
                        mean = 0;
                        break;
                    }
                    else
                    {
                        mean = Manipulation(x, y, calculator.Division);
                        choice = !double.IsInfinity(mean);
                        break;
                    }
                default:
                    mean = 0;
                    choice = false;
                    break;
            }
            return choice;
        }
        /// <summary>
        /// Method of calculator action execution.
        /// </summary>
        /// <param name="x">Prarmeter of <see cref="System.Double" /> type. Value for calculation.</param>
        /// <param name="y">Prarmeter of <see cref="System.Double" /> type. Value for calculation.</param>
        /// <param name="func">Delegate <see cref="System.Func{T1, T2, TResult}"/> accepting the method to be executed.</param>
        private static double Manipulation(double x, double y, Func<double, double, double> func)
        {
            Validation valid = new Validation();
            double mean = func.Invoke(x, y);//----Result of operation.

            //----Here we check if our values out of <see cref="System.Double" /> range. If IsInfinity() "true", write in console result of <param name="func"/> delegate, else output Error message.
            if (!valid.IsBordered(x) && !valid.IsBordered(y) && !double.IsInfinity(mean))
                return mean;
            else { Console.WriteLine("The result exceed the limit value of double type."); return mean; }
        }
    }
}