using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClass
{
    /// <summary>
    /// Part of class Money, to collect money. 
    /// </summary>
    public partial class Money : IProfitable
    {
        /// <summary>
        /// Method for collecting money in bank.
        /// </summary>
        /// <param name="years">Parameter of type <see cref="byte"/>.How many years we want to collect them.</param>
        /// <param name="coefficient">The growth rate of profit. Parameter of type <see cref="byte"/>.</param>
        /// <returns>How much money collected.</returns>
        public ulong InBank(byte years, byte coefficient)
        {
            if (Count != 0)
            {
                this.Count = Count * coefficient * years;
                return _count;
            }
            throw new Exception("No money for put it in Bank.");
        }
        /// <summary>
        /// Method for collecting money at home.
        /// </summary>
        /// <param name="months">Parameter of type <see cref="byte"/>. Number of monthes while we collect money.</param>
        /// <returns>How much money collected.</returns>
        public ulong AtHome(byte months)
        {
            if (Count != 0)
            {
                this.Count *= months;
                return this.Count;
            }
            throw new Exception("No money for collect at home.");

        }
    }
}
