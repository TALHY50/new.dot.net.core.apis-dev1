using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Company;
using ACL.Application.Domain.Ports.Repositories.Company;

namespace ACL.Application.Domain.Ports.Services.Company
{
    public interface IAclCompanyModuleService : IAclCompanyModuleRepository   
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse AddAclCompanyModule(AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        AclResponse EditAclCompanyModule(ulong id, AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteCompanyModule(ulong id);
        /// <inheritdoc/>
        bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0);
        /// <inheritdoc/>
        AclCompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong id = 0, AclCompanyModule? companyModule = null);
    }
}
