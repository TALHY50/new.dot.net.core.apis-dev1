using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
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
