using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Entities;

namespace ACL.Bussiness.Domain.Services
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
