using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclCompanyRepository : IGenericRepository<AclCompany>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> AddAclCompany(AclCompanyRequest module);
        Task<AclResponse> EditAclCompany(ulong Id, AclCompanyRequest module);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteCompany(ulong id);
        bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0);
        AclCompanyModule PrepareInputData(AclCompanyRequest request, ulong Id = 0, AclCompany aclCompany = null);

    }
}
