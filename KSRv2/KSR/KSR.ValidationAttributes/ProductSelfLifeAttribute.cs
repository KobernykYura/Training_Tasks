using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ProductSelfLifeAttribute : ValidationAttribute
    {
        public DateTime OtherProperty { get; }

        public ProductSelfLifeAttribute(DateTime otherProperty)
        {
            this.OtherProperty = otherProperty;
        }

        public ProductSelfLifeAttribute(DateTime otherProperty, string message)
        {
            this.OtherProperty = otherProperty;
            this.ErrorMessage = message;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string userName = value.ToString();
                if (!userName.StartsWith("T"))
                    return true;
                else
                    this.ErrorMessage = "Имя не должно начинаться с буквы T";
            }
            return false;
        }
    }
}
