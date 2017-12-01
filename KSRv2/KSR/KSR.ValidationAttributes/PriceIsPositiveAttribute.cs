using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PriceIsPositiveAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                decimal price;

                try
                {
                    price = (decimal)value;
                }
                catch (InvalidCastException)
                {
                    price = -1;
                }

                if (price < 0)
                    return false;
                else
                    this.ErrorMessage = "Price can't be negative.";
            }
            return false;
        }
    }
}
