using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclStateRepository : IGenericRepository<AclState>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> Add(AclStateRequest state);
        Task<AclResponse> Edit(ulong id, AclStateRequest state);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);

    }
}
