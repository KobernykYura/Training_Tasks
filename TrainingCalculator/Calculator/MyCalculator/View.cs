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
            string arg;
            do
            {
                Console.WriteLine("Please select an operation + - / * on numbers.\nTo exit, type \"exit\".");
                arg = Console.ReadLine();            
                double mean;

                //----Condition of error message.
                if (ViewLogic.SwitchCase(arg,x,y, out mean))
                {
                    Result(mean, arg, x, y);     //----Execute method <see cref="Result(double, string, double, double)"/>.
                }
                else Console.WriteLine("Error. Invalid command\n");

                //----Input of new values.
                Console.WriteLine("Input new values.");
                x = Input(1);
                y = Input(2);

            } while (arg != "exit");
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
