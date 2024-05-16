using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces;
using ACL.Infrastructure.Database;

namespace ACL.Contracts.Requests.CustomDataAnotator
{
    public class ArrayOfIntegersAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            ApplicationDbContext dbContext = new ApplicationDbContext();
            foreach (var pageId in (Int32[])value)
            {
                if (!dbContext.AclPages.Any(r => r.Id == (ulong)pageId))
                {
                    return new ValidationResult($"Role with ID {pageId} does not exist");
                }
            }

            return ValidationResult.Success;
        }
    }

}
