using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclPasswordRepository:IGenericRepository<AclUser>
    {
        Task<AclResponse> Reset(AclPasswordResetRequest request);
        Task<AclResponse> Forget(AclForgetPasswordRequest request);
        Task<AclResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request);
        

    }
}
