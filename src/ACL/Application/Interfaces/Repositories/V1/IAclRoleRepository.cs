using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1

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
