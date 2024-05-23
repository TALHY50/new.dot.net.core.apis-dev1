using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;

namespace ACL.Application.Ports.Repositories.Company
{
    /// <inheritdoc/>
    public interface IAclCompanyModuleRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> AddAclCompanyModule(AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        Task<AclResponse> EditAclCompanyModule(ulong id, AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        Task<AclResponse> DeleteCompanyModule(ulong id);
        /// <inheritdoc/>
        bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0);
        /// <inheritdoc/>
        AclCompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong id = 0, AclCompanyModule? companyModule = null);
        /// <inheritdoc/>
        List<AclCompany>? All();
        /// <inheritdoc/>
        AclCompanyModule? Find(ulong id);
        /// <inheritdoc/>
        AclCompanyModule? Add(AclCompanyModule aclCompanyModule);
        /// <inheritdoc/>
        AclCompanyModule? Update(AclCompanyModule aclCompanyModule);
        /// <inheritdoc/>
        AclCompanyModule? Delete(AclCompanyModule aclCompanyModule);
        /// <inheritdoc/>
        AclCompanyModule? Delete(ulong id);

    }
}
