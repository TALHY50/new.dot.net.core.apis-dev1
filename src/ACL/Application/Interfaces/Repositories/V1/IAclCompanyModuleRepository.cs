﻿using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclCompanyModuleRepository 
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> AddAclCompanyModule(AclCompanyModuleRequest module);
        Task<AclResponse> EditAclCompanyModule(ulong Id, AclCompanyModuleRequest module);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteCompanyModule(ulong id);
        bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0);
        AclCompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong Id = 0, AclCompanyModule aclCompany = null);

    }
}