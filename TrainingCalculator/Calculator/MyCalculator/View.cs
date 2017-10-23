using System;

namespace MyCalculator
{
    /// <summary>
    /// Provides the console user interface and user input.
    /// </summary>
    static class View
    {
        private static string StrLine { get; set; }
        private static double Value { get; set; }

        public static double Input(int i)
        {
            Validation valid = new Validation();

            Console.Write($"Input value {i}: ");
            StrLine = Console.ReadLine();

            double result = default(double);
            while (!valid.TryDouble(StrLine, out result))
            {
                Console.Write("Invalid input, enter the required double type: ");
                StrLine = Console.ReadLine();
            }

            return result;
        }

        public static void Menu(double x, double y)
        {
            CalculatorMethods calculator = new CalculatorMethods();

            string arg;
            while ((arg = Console.ReadLine()) != "exit")
            {
                Console.WriteLine("Please select an operation on numbers.\nTo exit, type \"exit\".");
                switch (arg)
                {
                    case "+":
                        Result(calculator.Summation(x, y), arg);
                        break;
                    case "*":
                        Result(calculator.Summation(x, y), arg);
                        break;
                    case "-":
                        Result(calculator.Summation(x, y), arg);
                        break;
                    case "/":
                        if (y == 0)
                        {
                            Console.WriteLine("You can not divide by zero.");
                            break;
                        }
                        Result(calculator.Summation(x, y), arg);
                        break;
                    default:
                        Console.WriteLine("Error. Unknown command");
                        break;
                }
            }
        }

        private static void Result(double result, string name)
        {
            Console.WriteLine($"");
        }
    }
}
