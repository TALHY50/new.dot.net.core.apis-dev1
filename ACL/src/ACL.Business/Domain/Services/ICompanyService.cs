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
        ScopeResponse EditAclCompany(uint id, AclCompanyEditRequest module);
        /// <inheritdoc/>
        ScopeResponse FindById(uint id);
        /// <inheritdoc/>
        ScopeResponse DeleteCompany(uint id);
        /// <inheritdoc/>
        Company PrepareInputData(AclCompanyCreateRequest? request = null, AclCompanyEditRequest? editRequest = null, Company? company = null);
    }
}
