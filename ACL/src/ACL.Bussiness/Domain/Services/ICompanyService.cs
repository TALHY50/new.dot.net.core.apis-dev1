using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Entities;

namespace ACL.Bussiness.Domain.Services
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
