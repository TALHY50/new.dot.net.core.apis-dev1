
using System.ComponentModel;
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("Password")]
    [ApiController]
    public class AclPasswordController : ControllerBase
    {
        private readonly ICustomUnitOfWork _unitOfWork;
        public AclPasswordController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost(Route.AclRoutesUrl.AclPassword.Reset, Name = Route.AclRoutesName.AclPassword.Reset)]
        public async Task<AclResponse> ResetPassword(AclPasswordResetRequest request)
        {
            return await _unitOfWork.AclPasswordRepository.Reset(request);
        }
        [HttpPost(Route.AclRoutesUrl.AclPassword.Forget, Name = Route.AclRoutesName.AclPassword.Forget)]
        public async Task<AclResponse> ForgetPassword(AclForgetPasswordRequest request)
        {
            return await _unitOfWork.AclPasswordRepository.Forget(request);
        }
        [HttpPost(Route.AclRoutesUrl.AclPassword.VerifyToken, Name = Route.AclRoutesName.AclPassword.VerifyToken)]
        public async Task<AclResponse>VerifyTokenAndUpdatePassword(AclForgetPasswordTokenVerifyRequest request)
        {
            return await _unitOfWork.AclPasswordRepository.VerifyToken(request);
        }



    }
}
