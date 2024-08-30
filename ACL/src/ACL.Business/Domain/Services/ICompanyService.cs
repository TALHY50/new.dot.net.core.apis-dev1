using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
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
