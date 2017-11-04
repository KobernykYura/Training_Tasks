using System;

namespace PartialClass
{
    /// <summary>
    /// Main part of class Money, to change currency and constructors.
    /// </summary>
    public partial class Money : IConvertible
    {
        /// <summary>
        /// Amount of money.
        /// </summary>
        protected ulong _count;
        /// <summary>
        /// Currency of money.
        /// </summary>
        protected string _currency;

        public ulong Count { get => _count; set => this._count = value; }
        public string Currency { get => _currency; set => _currency = value; }

        public Money()
        {
            this._count = 100;
            this._currency = "Euro";
        }
        /// <summary>
        /// Constructor with all parameters of main part.
        /// </summary>
        /// <param name="count">Amount of money.</param>
        /// <param name="currency">Currency of money.</param>
        public Money(uint count, string currency)
        {
            this._count = count;
            this._currency = currency;
        }

        /// <summary>
        /// Change currency and recount money.
        /// </summary>
        /// <param name="currency">Parameter of type <see cref="String"/>. New currency.</param>
        /// <param name="coefficient">Parameter of type <see cref="byte"/>. Coefficient of new currency.</param>
        /// <returns>How much money we have after changing.</returns>
        public ulong ChangeСurrency(string currency, byte coefficient)
        {
            if (Count != 0)
            {
                this.Currency = currency;
                this.Count *= coefficient;
                return _count;
            } throw new Exception("No money for change currency.");
        }
    }
}
