using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Company;
using ACL.Application.Domain.Ports.Repositories.Company;

namespace ACL.Application.Domain.Ports.Services.Company
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
