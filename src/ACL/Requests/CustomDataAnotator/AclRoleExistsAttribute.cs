using ACL.Interfaces;
using ACL.Requests.V1;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.CustomDataAnotator
{
    public class AclRoleExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var unitOfWork = serviceProvider.GetService(typeof(ICustomUnitOfWork)) as ICustomUnitOfWork;

            foreach (var roleId in (ulong[])value)
            {
                if (!(unitOfWork.ApplicationDbContext.AclRoles.Any(r => r.Id == roleId)))
                {
                    return new ValidationResult($"Role with ID {roleId} does not exist");
                }
            }

            return ValidationResult.Success;
        }
    }
}
