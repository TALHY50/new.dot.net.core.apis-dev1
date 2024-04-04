using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories
{
    public interface IAclModuleRepository : IGenericRepository<AclModule>
    {
        AclResponse GetAll();
        AclResponse FindById(ulong id);
        AclResponse AddAclModule(AclModuleRequest request);
        AclResponse EditAclModule(ulong Id, AclModuleRequest request);
        AclResponse DeleteModule(ulong id);
    }
}
