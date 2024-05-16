using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclUserUserGroupRepository
    {
        List<AclUserUsergroup> GetAll();
        AclUserUsergroup Add(AclUserUsergroup request);
        AclUserUsergroup Edit(ulong id, AclUserUsergroup request);
        AclUserUsergroup FindById(ulong id);
        AclUserUsergroup DeleteById(ulong id);
    }
}
