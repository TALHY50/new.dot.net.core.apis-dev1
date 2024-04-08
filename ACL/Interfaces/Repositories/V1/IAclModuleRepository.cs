using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclModuleRepository : IGenericRepository<AclModule>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> AddAclModule(AclModuleRequest request);
        Task<AclResponse> EditAclModule(ulong Id, AclModuleRequest request);
        Task<AclResponse> DeleteModule(ulong id);
    }
}
