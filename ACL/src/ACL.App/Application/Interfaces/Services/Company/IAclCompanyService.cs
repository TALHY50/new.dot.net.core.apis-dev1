using ACL.App.Application.Interfaces.Repositories.Company;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.Company;

namespace ACL.App.Application.Interfaces.Services.Company
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
