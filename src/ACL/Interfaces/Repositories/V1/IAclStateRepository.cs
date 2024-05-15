using ACL.Core.Models;
using ACL.Requests;
using ACL.Response.V1;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;

namespace ACL.Interfaces.Repositories.V1
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
