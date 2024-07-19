using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Company;
using ACL.App.Domain.Ports.Repositories.Company;

namespace ACL.App.Domain.Ports.Services.Company
{
    public interface IAclCompanyService : IAclCompanyRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        Task<AclResponse> AddAclCompany(AclCompanyCreateRequest module);
        /// <inheritdoc/>
        AclResponse EditAclCompany(ulong id, AclCompanyEditRequest module);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteCompany(ulong id);
        /// <inheritdoc/>
        AclCompany PrepareInputData(AclCompanyCreateRequest? request = null, AclCompanyEditRequest? editRequest = null, AclCompany? company = null);
    }
}
