using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;


namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclModuleRepository 
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> AddAclModule(AclModuleRequest request);
        Task<AclResponse> EditAclModule(ulong Id, AclModuleRequest request);
        Task<AclResponse> DeleteModule(ulong id);
        bool ExistByName(ulong id, string name);
        bool ExistById(ulong? id, ulong value);
    }
}
