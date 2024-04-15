
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclPasswordRepository
    {
        AclResponse Reset(AclPasswordResetRequest request);
        AclResponse Forget(AclForgetPasswordRequest request);
        AclResponse VerifyToken(AclForgetPasswordTokenVerifyRequest request);
        

    }
}
