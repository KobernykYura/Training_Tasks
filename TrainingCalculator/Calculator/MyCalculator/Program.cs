using System;

namespace MyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = View.Input(1);
            double y = View.Input(2);
            View.Menu(x, y);
        }
    }
}
