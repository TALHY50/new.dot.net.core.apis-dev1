using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1

{
    public interface IAclCountryRepository
    {
        AclResponse GetAll();
        AclResponse Add(AclCountryRequest request);
        AclResponse Edit(ulong id, AclCountryRequest request);
        AclResponse FindById(ulong id);
        AclResponse DeleteById(ulong id);
        bool ExistById(ulong id);
    }
}
