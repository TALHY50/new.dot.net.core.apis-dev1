using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Entities;

namespace ACL.App.Domain.Services
{
    public interface ICompanyService : ICompanyRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        Task<ScopeResponse> AddAclCompany(AclCompanyCreateRequest module);
        /// <inheritdoc/>
        ScopeResponse EditAclCompany(ulong id, AclCompanyEditRequest module);
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
        /// <inheritdoc/>
        ScopeResponse DeleteCompany(ulong id);
        /// <inheritdoc/>
        Company PrepareInputData(AclCompanyCreateRequest? request = null, AclCompanyEditRequest? editRequest = null, Company? company = null);
    }
}
