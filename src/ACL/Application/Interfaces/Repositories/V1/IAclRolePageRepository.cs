using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclRolePageRepository : IGenericRepository<AclRolePage>
    {
        Task<AclResponse> GetAllById(ulong Id);
        Task<AclResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest req);
        AclRolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest req);
    }
}
