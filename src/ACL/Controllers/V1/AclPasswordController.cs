
using System.ComponentModel;
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("Password")]
    [ApiController]
    [Route(Route.AclRoutesUrl.Base)]
    public class AclPasswordController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        public AclPasswordController(IUnitOfWork repository)
        {
            _repository = repository;
        }

        [HttpPost(Route.AclRoutesUrl.AclPassword.Reset, Name = Route.AclRoutesName.AclPassword.Reset)]
        public async Task<AclResponse> ResetPassword(AclPasswordResetRequest request)
        {
            return _repository.AclPasswordRepository.Reset(request);
        }
        [HttpPost(Route.AclRoutesUrl.AclPassword.Forget, Name = Route.AclRoutesName.AclPassword.Forget)]
        public async Task<AclResponse> ForgetPassword(AclForgetPasswordRequest request)
        {
            return _repository.AclPasswordRepository.Forget(request);
        }
        [HttpPost(Route.AclRoutesUrl.AclPassword.VerifyToken, Name = Route.AclRoutesName.AclPassword.VerifyToken)]
        public async Task<AclResponse>VerifyTokenAndUpdatePassword(AclForgetPasswordTokenVerifyRequest request)
        {
            return _repository.AclPasswordRepository.VerifyToken(request);
        }



    }
}
