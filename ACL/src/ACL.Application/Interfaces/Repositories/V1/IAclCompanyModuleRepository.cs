using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Entities;
using ACL.Core.Entities.Company;

namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclCompanyModuleRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> AddAclCompanyModule(AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        Task<AclResponse> EditAclCompanyModule(ulong Id, AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        Task<AclResponse> DeleteCompanyModule(ulong id);
        /// <inheritdoc/>
        bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0);
        /// <inheritdoc/>
        AclCompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong Id = 0, AclCompanyModule aclCompanyModule = null);
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
