﻿using ACL.Interfaces;
using ACL.Requests.V1;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.CustomDataAnotator
{
    public class UniqueCompanyModuleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var unitOfWork = serviceProvider.GetService(typeof(ICustomUnitOfWork)) as ICustomUnitOfWork;

            if (unitOfWork == null)
            {
                throw new InvalidOperationException("Not found.");
            }

            var request = (AclCompanyModuleRequest)validationContext.ObjectInstance;

            bool isUnique = unitOfWork.ApplicationDbContext.AclCompanyModules
                                .Any(a => a.CompanyId == request.company_id && a.ModuleId == request.module_id) && unitOfWork.ApplicationDbContext.AclCompanies.Any(x=>x.Id==request.company_id) && unitOfWork.ApplicationDbContext.AclModules.Any(x=>x.Id == request.module_id);

            if (!isUnique)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The combination of Company ID and Module ID already exists.");
        }
    }
}
