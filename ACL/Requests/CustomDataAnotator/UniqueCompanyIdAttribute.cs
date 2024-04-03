using ACL.Interfaces;
using ACL.Requests.V1;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.CustomDataAnotator
{
    public class UniqueCompanyIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var unitOfWork = serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;

            if (unitOfWork == null)
            {
                throw new InvalidOperationException("IUnitOfWork service not found.");
            }

            var request = (AclCompanyModuleRequest)validationContext.ObjectInstance;

            // Check uniqueness constraint in the database
            bool isUnique = unitOfWork.ApplicationDbContext.AclCompanyModules
                                .Any(a => a.CompanyId == request.company_id && a.ModuleId == request.module_id);

            if (!isUnique)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The combination of Company ID and Module ID already exists.");
        }
    }
}
