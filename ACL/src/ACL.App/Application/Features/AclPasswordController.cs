using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common.Constants;

namespace ACL.Web.Application.Features
{
    /// <inheritdoc/>
    //[Authorize]
    [Tags("Password")]
    [ApiController]
    public class AclPasswordController : ControllerBase
    {
        private readonly IPasswordRepository _repository;
        /// <inheritdoc/>
        public AclPasswordController(IPasswordRepository repository)
        {
            _repository = repository;
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPasswordRouteUrl.Reset, Name = AclRoutesName.AclPasswordRouteNames.Reset)]
        public async Task<ScopeResponse> ResetPassword(AclPasswordResetRequest request)
        {
            return await _repository.Reset(request);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPasswordRouteUrl.Forget, Name = AclRoutesName.AclPasswordRouteNames.Forget)]
        public ScopeResponse ForgetPassword(AclForgetPasswordRequest request)
        {
            return _repository.Forget(request);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclPasswordRouteUrl.VerifyToken, Name = AclRoutesName.AclPasswordRouteNames.VerifyToken)]
        public async Task<ScopeResponse> VerifyTokenAndUpdatePassword(AclForgetPasswordTokenVerifyRequest request)
        {
            return await _repository.VerifyToken(request);
        }



    }
}
