
using ACL.Database.Models;
using ACL.Requests;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1

{
    public interface IAclRoleRepository : IGenericRepository<AclRole>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> Add(AclRoleRequest subModule);
        Task<AclResponse> Edit(ulong id, AclRoleRequest subModule);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);
    }
}
