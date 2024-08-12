﻿using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8765 // Possible null reference argument.
namespace SharedKernel.Main.Infrastructure.Attributes
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