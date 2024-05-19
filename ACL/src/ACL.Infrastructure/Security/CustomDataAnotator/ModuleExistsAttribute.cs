using System.ComponentModel.DataAnnotations;
using ACL.Application.Ports.Repositories;

namespace ACL.Infrastructure.Security.CustomDataAnotator
{
    public class ModuleExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ulong id = 0;
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var _moduleRepository = serviceProvider.GetService(typeof(IAclModuleRepository)) as IAclModuleRepository;

            if (value == null || _moduleRepository == null)
            {
                return new ValidationResult($"The value is not null.");
            }
            bool module = _moduleRepository.ExistById(id,(ulong)value);
            if (!module)
            {
                return new ValidationResult($"The '{value}' is not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
