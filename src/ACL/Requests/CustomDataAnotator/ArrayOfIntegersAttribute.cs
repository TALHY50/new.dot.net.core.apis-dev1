﻿namespace ACL.Requests.CustomDataAnotator
{
    using ACL.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ArrayOfIntegersAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var unitOfWork = serviceProvider.GetService(typeof(ICustomUnitOfWork)) as ICustomUnitOfWork;
            foreach (var pageId in (Int32[])value)
            {
                if (!unitOfWork.ApplicationDbContext.AclPages.Any(r => r.Id == (ulong)pageId))
                {
                    return new ValidationResult($"Role with ID {pageId} does not exist");
                }
            }

            return ValidationResult.Success;
        }
    }

}