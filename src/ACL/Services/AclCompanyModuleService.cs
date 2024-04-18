using ACL.Interfaces;
using ACL.Requests.V1;
using System.ComponentModel.DataAnnotations;

namespace ACL.Services
{
    public class AclCompanyModuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AclCompanyModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ValidationResult ValidateAclCompanyModule(AclCompanyModuleRequest request)
        {
            bool isUnique = _unitOfWork.ApplicationDbContext.AclCompanyModules
                                .Any(a => a.CompanyId == request.company_id && a.ModuleId == request.module_id);

            if (!isUnique)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The combination of Company ID and Module ID already exists.");
        }
    }
}
