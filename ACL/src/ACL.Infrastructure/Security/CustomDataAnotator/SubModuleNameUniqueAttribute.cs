using System.ComponentModel.DataAnnotations;
using ACL.Application.Ports.Repositories;
using Microsoft.AspNetCore.Http;

namespace ACL.Infrastructure.Security.CustomDataAnotator
{
    public class SubModuleNameUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ulong id = 0;
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
          
            var httpContext = (serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor)?.HttpContext;
            var idValue = httpContext?.Request.RouteValues["id"]?.ToString();

            var _subModuleRepository = serviceProvider.GetService(typeof(IAclSubModuleRepository)) as IAclSubModuleRepository;
            

            if (value == null || _subModuleRepository == null)
            {
                return new ValidationResult($"The value is not null.");
            }
            if(idValue != null)
            {
                id = ulong.Parse(idValue);
            }
            bool state = _subModuleRepository.ExistByName(id,(string)value);
            if (state)
            {
                return new ValidationResult($"The '{value}' is not unique.");
            }

            return ValidationResult.Success;
        }
    }
}
