using ACL.Database.Models;
using ACL.Requests;

namespace ACL.Interfaces.Repositories
{
    public interface IAclCompanyModuleRepository : IGenericRepository<AclCompanyModule>
    {
        AclCompanyModule FindByCompanyId(ulong id);
        IList<AclCompanyModule> GetAll();
        AclCompanyModule FindByModuleId(ulong id);
        bool IsExistCompanyId(ulong id);
        bool IsExistModuleId(ulong id);
        AclCompanyModule Add(AclCompanyModule module);
        AclCompanyModule AddAclCompanyModule(AclCompanyModuleRequest module);
        AclCompanyModule FindById(ulong id);
        bool UpdateModule(ulong id, AclCompanyModule module);
        bool DeleteModule(ulong id);
        bool IsValidForCreateOrUpdate(ulong companyId,ulong moduleId);

    }
}
