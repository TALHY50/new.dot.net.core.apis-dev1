using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Ports.Repositories.Auth;
using Notification.Application.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
     /// <inheritdoc/>
    //[Authorize]
    [Tags("Password")]
    [ApiController]
    public class AclPasswordController : ControllerBase
    {
        private readonly IAclPasswordRepository _repository;
         /// <inheritdoc/>
        public AclPasswordController(IAclPasswordRepository repository)
        {
            this._repository = repository;
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPasswordRouteUrl.Reset, Name = AclRoutesName.AclPasswordRouteNames.Reset)]
        public async Task<AclResponse> ResetPassword(AclPasswordResetRequest request)
        {
            return await this._repository.Reset(request);
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPasswordRouteUrl.Forget, Name = AclRoutesName.AclPasswordRouteNames.Forget)]
        public AclResponse ForgetPassword(AclForgetPasswordRequest request)
        {
            return  this._repository.Forget(request);
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPasswordRouteUrl.VerifyToken, Name = AclRoutesName.AclPasswordRouteNames.VerifyToken)]
        public async Task<AclResponse> VerifyTokenAndUpdatePassword(AclForgetPasswordTokenVerifyRequest request)
        {
            return await this._repository.VerifyToken(request);
        }



    }
}
