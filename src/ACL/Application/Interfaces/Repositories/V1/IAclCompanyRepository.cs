using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclCompanyRepository 
        Task<AclResponse> GetAll();
        Task<AclResponse> AddAclCompany(AclCompanyCreateRequest module);
        Task<AclResponse> EditAclCompany(ulong Id, AclCompanyEditRequest module);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteCompany(ulong id);
        AclCompany PrepareInputData(AclCompanyCreateRequest request=null,AclCompanyEditRequest req = null,  AclCompany aclCompany = null);

    }
}
