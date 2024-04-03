using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories
{
    public interface IAclCompanyModuleRepository : IGenericRepository<AclCompanyModule>
    {
        AclResponse GetAll();
        AclResponse AddAclCompanyModule(AclCompanyModuleRequest module);
        AclResponse EditAclCompanyModule(ulong Id,AclCompanyModuleRequest module);
        AclResponse FindById(ulong id);
        AclResponse DeleteModule(ulong id);
        bool IsValidForCreateOrUpdate(ulong companyId,ulong moduleId,ulong id=0);
        AclCompanyModule prepareInputData(AclCompanyModuleRequest request,ulong Id =0);

    }
}
