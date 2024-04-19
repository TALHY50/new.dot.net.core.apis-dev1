
using ACL.Database.Models;
using ACL.Requests;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclSubModuleRepository:IGenericRepository<AclSubModule>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> Add(AclSubModuleRequest subModule);
        Task<AclResponse> Edit(ulong id, AclSubModuleRequest subModule);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);

    }
}
