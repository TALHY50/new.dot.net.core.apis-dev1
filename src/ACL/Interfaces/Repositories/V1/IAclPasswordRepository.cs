
using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclPasswordRepository:IGenericRepository<AclUser>
    {
        Task<AclResponse> Reset(AclPasswordResetRequest request);
        Task<AclResponse> Forget(AclForgetPasswordRequest request);
        Task<AclResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request);
        

    }
}
