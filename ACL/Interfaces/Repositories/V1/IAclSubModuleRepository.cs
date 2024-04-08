using ACL.Database.Models;
using ACL.Requests;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclSubModuleRepository
    {
        AclResponse GetAll();
        AclResponse Add(AclSubModuleRequest subModule);
        AclResponse Edit(ulong id, AclSubModuleRequest subModule);
        AclResponse findById(ulong id);
        AclResponse deleteById(ulong id);

    }
}
