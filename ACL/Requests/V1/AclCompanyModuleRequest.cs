using ACL.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1
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
    public partial class AclCompanyModuleRequest
    {
        [Required]
        [Range(1, ulong.MaxValue)]
        [UniqueCompanyId]
        public ulong company_id { get; set; }

        [Required]
        [Range(1, ulong.MaxValue)]
        [UniqueCompanyId]
        public ulong module_id { get; set; }
    }


}
