using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClass
{
    /// <summary>
    /// Part of class Money, to spend money.
    /// </summary>
    public partial class Money : IWasteful
    {
        /// <summary>
        /// Method of spending money in casino.
        /// </summary>
        /// <param name="hours">The amount of time spent at a casino.</param>
        /// <param name="price">The price for the entrance to the casino.</param>
        /// <returns>How much money left.</returns>
        public ulong InCasino(byte hours, byte price)
        {
            // If we can pay for entrance, we spend our money
            if (Count > price) 
            {
                Count -= price;
                return Count = Count / hours*2;

            } throw new Exception($"You can't get play in casino, until your count of money({Count} {Currency}) will not more than {price} {Currency}");
        }
        /// <summary>
        /// Method of paying the debt.
        /// </summary>
        /// <param name="debt">Debt required in return.</param>
        /// <returns>How much money left.</returns>
        public ulong RepayDebt(byte debt)
        {
            if (Count > debt)
            {
                return Count -= debt;

            } throw new Exception($"You haven't enough money to repay debt.");
        }
    }
}
