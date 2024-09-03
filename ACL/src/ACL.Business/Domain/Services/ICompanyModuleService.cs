using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
{
    public interface ICompanyModuleService : ICompanyModuleRepository   
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse AddAclCompanyModule(AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        ScopeResponse EditAclCompanyModule(uint id, AclCompanyModuleRequest companyModule);
        /// <inheritdoc/>
        ScopeResponse FindById(uint id);
        /// <inheritdoc/>
        ScopeResponse DeleteCompanyModule(uint id);
        /// <inheritdoc/>
        bool IsValidForCreateOrUpdate(uint companyId, uint moduleId, uint id = 0);
        /// <inheritdoc/>
        CompanyModule PrepareInputData(AclCompanyModuleRequest request, uint id = 0, CompanyModule? companyModule = null);
    }
}
