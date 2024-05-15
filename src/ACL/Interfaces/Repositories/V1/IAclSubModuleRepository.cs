using ACL.Core.Models;
using ACL.Requests;
using ACL.Response.V1;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;

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
