using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclModuleRepository 
    {
        AclResponse GetAll();
        AclResponse FindById(ulong id);
        AclResponse AddAclModule(AclModuleRequest request);
        AclResponse EditAclModule(ulong Id, AclModuleRequest request);
        AclResponse DeleteModule(ulong id);
    }
}
