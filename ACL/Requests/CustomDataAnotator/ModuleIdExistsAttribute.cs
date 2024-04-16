using ACL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.CustomDataAnotator
{
    public class ModuleIdExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var unitOfWork = serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;

            if ((ulong)value > 0 && !(unitOfWork.ApplicationDbContext.AclModules.Any(r => r.Id == (ulong)value)))
            {
                return new ValidationResult($"ModuleId does not exist");
            }

            return ValidationResult.Success;

        }
    }
}
