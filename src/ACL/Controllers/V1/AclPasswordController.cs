
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

        [HttpPost(Route.AclRoutesUrl.AclPasswordRouteUrl.Reset, Name = Route.AclRoutesName.AclPasswordRouteNames.Reset)]
        public async Task<AclResponse> ResetPassword(AclPasswordResetRequest request)
        {
            return await _unitOfWork.AclPasswordRepository.Reset(request);
        }
        [HttpPost(Route.AclRoutesUrl.AclPasswordRouteUrl.Forget, Name = Route.AclRoutesName.AclPasswordRouteNames.Forget)]
        public async Task<AclResponse> ForgetPassword(AclForgetPasswordRequest request)
        {
            return await _unitOfWork.AclPasswordRepository.Forget(request);
        }
        [HttpPost(Route.AclRoutesUrl.AclPasswordRouteUrl.VerifyToken, Name = Route.AclRoutesName.AclPasswordRouteNames.VerifyToken)]
        public async Task<AclResponse>VerifyTokenAndUpdatePassword(AclForgetPasswordTokenVerifyRequest request)
        {
            return await _unitOfWork.AclPasswordRepository.VerifyToken(request);
        }



    }
}
