using ACL.Database.Models;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclPageRepository : IGenericRepository<AclPage>
    {
        AclPage FindByModuleId(ulong ModuleId);
        AclPage FindBySubModuleId(ulong ModuleId);
        IList<AclPage> GetAll();
        AclPage Add(AclPage page);
        AclPage FindById(ulong Id);
        bool IsModuleIdExist(ulong ModuleId);
        bool IsSubModuleIdExist(ulong SubModuleId);
    }
}
