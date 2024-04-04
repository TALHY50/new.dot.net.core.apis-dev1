
using ACL.Database.Models;
using ACL.Requests;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories
{
    public interface IAclRoleRepository
    {
        AclResponse GetAll();
        AclResponse Add(AclRoleRequest subModule);
        AclResponse Edit(ulong id, AclRoleRequest subModule);
        AclResponse findById(ulong id);
        AclResponse deleteById(ulong id);

    }
}
