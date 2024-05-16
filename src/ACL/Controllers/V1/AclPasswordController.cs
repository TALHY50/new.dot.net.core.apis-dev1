

using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Tags("Password")]
    [ApiController]
    public class AclPasswordController : ControllerBase
    {
        private readonly IAclPasswordRepository _repository;
        public AclPasswordController(IAclPasswordRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclPasswordRouteUrl.Reset, Name = Route.AclRoutesName.AclPasswordRouteNames.Reset)]
        public async Task<AclResponse> ResetPassword(AclPasswordResetRequest request)
        {
            return await _repository.Reset(request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclPasswordRouteUrl.Forget, Name = Route.AclRoutesName.AclPasswordRouteNames.Forget)]
        public async Task<AclResponse> ForgetPassword(AclForgetPasswordRequest request)
        {
            return await _repository.Forget(request);
        }

        [Authorize(Policy = "HasPermission")]
        [HttpPost(Route.AclRoutesUrl.AclPasswordRouteUrl.VerifyToken, Name = Route.AclRoutesName.AclPasswordRouteNames.VerifyToken)]
        public async Task<AclResponse> VerifyTokenAndUpdatePassword(AclForgetPasswordTokenVerifyRequest request)
        {
            return await _repository.VerifyToken(request);
        }



    }
}
