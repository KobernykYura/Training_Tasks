using System;

namespace MyCalculator
{
    /// <summary>
    /// Provides the console user interface and user input.
    /// </summary>
    public static class View
    {
        /// <summary>
        /// The method of entering a value with the transfer of the index of the calculated value.
        /// </summary>
        /// <param name="i">Index of user's value.</param>
        /// <returns>Converted result of entered value in <see cref="System.Double"/> type.</returns>
        public static double Input(int i)
        {
            Validation valid = new Validation();
            double result = default(double);
            string StrLine;
            
            //---- First input.
            Console.Write($"Input value {i}: ");
            StrLine = Console.ReadLine();

            //---- TryParse parameter StrLine in double type. If TryDouble() returns "false"- output an error message, else return "true" and the "result" if successful.
            while (!valid.TryDouble(StrLine, out result))
            {
                Console.Write("Invalid input, enter the required double type: ");
                StrLine = Console.ReadLine();
            }

            return result;
        }

        /// <summary>
        /// User interaction menu and operations.
        /// </summary>
        /// <param name="x">Prarmeter of <see cref="System.Double" /> type. Value for calculation.</param>
        /// <param name="y">Prarmeter of <see cref="System.Double" /> type. Value for calculation.</param>
        public static void Menu(double x, double y)
        {
            CalculatorMethods calculator = new CalculatorMethods();

            string arg;
            do
            {
                Console.WriteLine("Please select an operation + - / * on numbers.\nTo exit, type \"exit\".");
                arg = Console.ReadLine();
                // Switch operation.
                switch (arg)
                {
                    case "+":
                        Manipulation(x, y, arg, calculator.Summation);
                        break;
                    case "*":
                        Manipulation(x, y, arg, calculator.Multiplication);
                        break;
                    case "-":
                        Manipulation(x, y, arg, calculator.Subtraction);
                        break;
                    case "/":
                        if (y == 0)
                        {
                            Console.WriteLine("You can not divide by zero.");
                            break;
                        }
                        Manipulation(x, y, arg, calculator.Division);
                        break;
                    default:
                        Console.WriteLine("Error. Unknown command");
                        break;
                }

                //----Input of new values.
                Console.WriteLine("Input new values.");
                x = Input(1);
                y = Input(2);

            } while (arg != "exit");
        }

        /// <summary>
        /// Method of calculator action execution.
        /// </summary>
        /// <param name="x">Prarmeter of <see cref="System.Double" /> type. Value for calculation.</param>
        /// <param name="y">Prarmeter of <see cref="System.Double" /> type. Value for calculation.</param>
        /// <param name="arg">Name of our operation. Parameter is <see cref="System.String"/> type.</param>
        /// <param name="func">Delegate <see cref="System.Func{T1, T2, TResult}"/> accepting the method to be executed.</param>
        public static void Manipulation(double x, double y, string arg, Func<double,double,double> func)
        {
            Validation valid = new Validation();
            double mean = func.Invoke(x, y);//----Result of operation.

            //----Here we check if our values out of <see cref="System.Double" /> range. If IsInfinity() "true", write in console result of <param name="func"/> delegate, else output Error message.
            if (!valid.IsBordered(x) && !valid.IsBordered(y) && !double.IsInfinity(mean))
                Result(mean, arg, x, y);     //----Execute method <see cref="Result(double, string, double, double)"/>.
            else Console.WriteLine("The result exceed the limit value of double type.");

        }

        /// <summary>
        /// Provides result <paramref name="result"/> of <paramref name="name"/>operation.
        /// </summary>
        /// <param name="result">Prarmeter of <see cref="System.Double" /> type. Result of calculation.</param>
        /// <param name="name">Prarmeter of <see cref="System.String" /> type. The name of operation..</param>
        /// <param name="x">Prarmeter of <see cref="System.Double" /> type. Value for calculation.</param>
        /// <param name="y">Prarmeter of <see cref="System.Double" /> type. Value for calculation.></param>
        private static void Result(double result, string name, double x, double y)
        {
            Console.WriteLine($"Result of operation {x}{name}{y}={result}\n");
        }
    }
}
