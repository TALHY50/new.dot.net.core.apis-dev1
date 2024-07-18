using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Company;
using App.Domain.Ports.Repositories.Company;

namespace App.Domain.Ports.Services.Company
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
