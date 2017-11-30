namespace EventReflection.Products
{
    public class PriceChangedEventArgs : System.EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal value)
        {
            LastPrice = NewPrice;
            NewPrice = value;
        }
    }
}