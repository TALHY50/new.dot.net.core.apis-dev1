using ACL.Interfaces;
using ACL.Requests;
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
                                .Any(a => a.CompanyId == request.CompanyId && a.ModuleId == request.ModuleId);

            if (!isUnique)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The combination of Company ID and Module ID already exists.");
        }
    }
}
