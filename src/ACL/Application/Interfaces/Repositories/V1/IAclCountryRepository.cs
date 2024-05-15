using ACL.Core.Models;
using ACL.Requests;
using ACL.Response.V1;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1

{
    public interface IAclCountryRepository : IGenericRepository<AclCountry>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> Add(AclCountryRequest request);
        Task<AclResponse> Edit(ulong id, AclCountryRequest request);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);
    }
}
