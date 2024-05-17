using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclCompanyRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> AddAclCompany(AclCompanyCreateRequest module);
        /// <inheritdoc/>
        Task<AclResponse> EditAclCompany(ulong Id, AclCompanyEditRequest module);
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        List<AclCompany>? All();
        /// <inheritdoc/>
        AclCompany? Find(ulong id);
        /// <inheritdoc/>
        AclCompany? Add(AclCompany aclCompany);
        /// <inheritdoc/>
        AclCompany? Update(AclCompany aclCompany);
        /// <inheritdoc/>
        AclCompany? Delete(AclCompany aclCompany);
        /// <inheritdoc/>
        Task<AclResponse> DeleteCompany(ulong id);
        /// <inheritdoc/>
        AclCompany PrepareInputData(AclCompanyCreateRequest request = null, AclCompanyEditRequest req = null, AclCompany aclCompany = null);

    }
}
