using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Entities;

namespace ACL.App.Domain.Services
{
    public interface ICompanyModuleService : ICompanyModuleRepository   
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse AddAclCompanyModule(AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        ScopeResponse EditAclCompanyModule(ulong id, AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
        /// <inheritdoc/>
        ScopeResponse DeleteCompanyModule(ulong id);
        /// <inheritdoc/>
        bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0);
        /// <inheritdoc/>
        CompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong id = 0, CompanyModule? companyModule = null);
    }
}
