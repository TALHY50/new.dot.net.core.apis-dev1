
using ACL.Database.Models;
using ACL.Requests;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1

{
    public interface IAclRoleRepository : IGenericRepository<AclRole>
    {
        AclResponse GetAll();
        AclResponse Add(AclRoleRequest subModule);
        AclResponse Edit(ulong id, AclRoleRequest subModule);
        AclResponse findById(ulong id);
        AclResponse deleteById(ulong id);
        uint SetCompanyId(uint companyId);
    }
}
