using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Repositories.Auth;
using App.Infrastructure.Route;
using Microsoft.AspNetCore.Mvc;

namespace App.Application.Controllers.V1
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
