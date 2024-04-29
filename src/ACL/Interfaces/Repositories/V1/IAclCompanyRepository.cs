using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclCompanyRepository : IGenericRepository<AclCompany>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> AddAclCompany(AclCompanyCreateRequest module);
        Task<AclResponse> EditAclCompany(ulong Id, AclCompanyEditRequest module);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteCompany(ulong id);
        AclCompany PrepareInputData(AclCompanyCreateRequest request=null,AclCompanyEditRequest req = null,  AclCompany aclCompany = null);

    }
}
