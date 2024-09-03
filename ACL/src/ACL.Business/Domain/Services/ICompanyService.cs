using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
{
    public interface ICompanyService : ICompanyRepository
    {
        /// <inheritdoc/>
        ApplicationResponse GetAll();
        /// <inheritdoc/>
        Task<ApplicationResponse> AddAclCompany(AclCompanyCreateRequest module);
        /// <inheritdoc/>
        ApplicationResponse EditAclCompany(uint id, AclCompanyEditRequest module);
        /// <inheritdoc/>
        ApplicationResponse FindById(uint id);
        /// <inheritdoc/>
        ApplicationResponse DeleteCompany(uint id);
        /// <inheritdoc/>
        Company PrepareInputData(AclCompanyCreateRequest? request = null, AclCompanyEditRequest? editRequest = null, Company? company = null);
    }
}
