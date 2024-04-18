using System;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.CustomDataAnotaTor
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NonZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false; // Property is required
            }

            int intValue;
            if (int.TryParse(value.ToString(), out intValue))
            {
                return intValue != 0;
            }

            return false; // Not an integer
        }
    }
}
