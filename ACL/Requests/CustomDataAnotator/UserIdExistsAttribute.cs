﻿using ACL.Interfaces;
using ACL.Requests.V1;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.CustomDataAnotator
{
    public class UserIdExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var unitOfWork = serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;


            if (!(unitOfWork.ApplicationDbContext.AclUsers.Any(r => r.Id == (ulong)value)))
            {
                return new ValidationResult($"UserId does not exist");
            }
          
            return ValidationResult.Success;
        }
    }
}
