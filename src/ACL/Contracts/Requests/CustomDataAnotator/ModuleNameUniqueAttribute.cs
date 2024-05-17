﻿using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces.Repositories.V1;

namespace ACL.Contracts.Requests.CustomDataAnotator
{
    public class ModuleNameUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ulong id = 0;
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
          
            var httpContext = (serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor)?.HttpContext;
            var idValue = httpContext?.Request.RouteValues["id"]?.ToString();

            var _moduleRepository = serviceProvider.GetService(typeof(IAclModuleRepository)) as IAclModuleRepository;
            

            if (value == null || _moduleRepository == null)
            {
                return new ValidationResult($"The value is not null.");
            }
            if(idValue != null)
            {
                id = ulong.Parse(idValue);
            }
            bool state = _moduleRepository.ExistByName(id,(string)value);
            if (state)
            {
                return new ValidationResult($"The '{value}' is not unique.");
            }

            return ValidationResult.Success;
        }
    }
}
