using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces;
using ACL.Infrastructure.Database;

namespace ACL.Contracts.Requests.CustomDataAnotator
{
    /// <inheritdoc/>
    public class ArrayOfIntegersAttribute : ValidationAttribute
    {
/// <inheritdoc/>

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            ApplicationDbContext dbContext = new ApplicationDbContext();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var pageId in value as int[])
            {
                if (!dbContext.AclPages.Any(r => r.Id == (ulong)pageId))
                {
                    return new ValidationResult($"Role with ID {pageId} does not exist");
                }
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

#pragma warning disable CS8603 // Possible null reference return.
            return ValidationResult.Success;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

}
