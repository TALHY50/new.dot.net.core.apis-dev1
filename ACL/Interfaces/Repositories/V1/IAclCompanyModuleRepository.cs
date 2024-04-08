using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclCompanyModuleRepository : IGenericRepository<AclCompanyModule>
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
