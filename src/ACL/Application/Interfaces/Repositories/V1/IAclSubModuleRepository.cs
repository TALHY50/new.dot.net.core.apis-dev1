using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;


namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclSubModuleRepository
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> Add(AclSubModuleRequest subModule);
        Task<AclResponse> Edit(ulong id, AclSubModuleRequest subModule);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);
        bool ExistByName(ulong id, string name);
        bool ExistById(ulong? id,ulong value);
    }
}
