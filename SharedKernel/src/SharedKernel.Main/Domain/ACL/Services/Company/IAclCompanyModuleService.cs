using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Company;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.Company;

namespace SharedKernel.Main.Domain.ACL.Services.Company
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
