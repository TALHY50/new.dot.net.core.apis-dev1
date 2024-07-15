using System.ComponentModel.DataAnnotations;
using ACL.Application.Infrastructure.Persistence.Configurations;

namespace ACL.Application.Infrastructure.Security.CustomDataAnotator
{
    /// <inheritdoc/>
    public class AclRoleExistsAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            ApplicationDbContext dbContext = new ApplicationDbContext();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (ulong roleId in value as ulong[])
            {
                if (!(dbContext.AclRoles.Any(r => r.Id == roleId)))
                {
                    return new ValidationResult($"Role with ID {roleId} does not exist");
                }
            }
#pragma warning disable CS8603 // Possible null reference return.
            return ValidationResult.Success;
        }
    }
}
