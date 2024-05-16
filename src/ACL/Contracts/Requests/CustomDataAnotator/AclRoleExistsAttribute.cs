using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces;
using ACL.Infrastructure.Database;

namespace ACL.Contracts.Requests.CustomDataAnotator
{
    public class AclRoleExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            ApplicationDbContext dbContext = new ApplicationDbContext();

            foreach (var roleId in (ulong[])value)
            {
                if (!(dbContext.AclRoles.Any(r => r.Id == roleId)))
                {
                    return new ValidationResult($"Role with ID {roleId} does not exist");
                }
            }

            return ValidationResult.Success;
        }
    }
}
