using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace ACL.Web.Application.Features.Passwords
{
     /// <inheritdoc/>
    //[Authorize]
    [Tags("Password")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordRepository _repository;
         /// <inheritdoc/>
        public PasswordController(IPasswordRepository repository)
        {
            this._repository = repository;
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPasswordRouteUrl.Reset, Name = AclRoutesName.AclPasswordRouteNames.Reset)]
        public async Task<ScopeResponse> ResetPassword(AclPasswordResetRequest request)
        {
            return await this._repository.Reset(request);
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPasswordRouteUrl.Forget, Name = AclRoutesName.AclPasswordRouteNames.Forget)]
        public ScopeResponse ForgetPassword(AclForgetPasswordRequest request)
        {
            return  this._repository.Forget(request);
        }
         /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPasswordRouteUrl.VerifyToken, Name = AclRoutesName.AclPasswordRouteNames.VerifyToken)]
        public async Task<ScopeResponse> VerifyTokenAndUpdatePassword(AclForgetPasswordTokenVerifyRequest request)
        {
            return await this._repository.VerifyToken(request);
        }



    }
}
