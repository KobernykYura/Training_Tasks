using System;

namespace KSR.Service
{
    public class ProductEventArgs : EventArgs
    {
        private string name;
        private double price;
        private int count;

        public ProductEventArgs(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public ProductEventArgs(int count, double price)
        {
            this.count = count;
            this.price = price;
        }
    }
}