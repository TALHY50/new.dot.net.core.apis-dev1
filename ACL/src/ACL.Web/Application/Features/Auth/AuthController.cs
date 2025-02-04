using ACL.Business.Application.Features.Auth;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.Auth
{
    [ApiExplorerSettings(IgnoreApi = true)]
    /// <inheritdoc/>
    [Route("api/v1/auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Login _login;
        private readonly RefreshToken _refreshToken;
        private readonly SignOut _signOut;
        private readonly Register _register;
        /// <inheritdoc/>
        public AuthController(
            Login login,
            RefreshToken refreshToken,
            SignOut signOut,
            Register register)
        {
            this._login = login;
            this._refreshToken = refreshToken;
            this._signOut = signOut;
            this._register = register;
        }
        /// <inheritdoc/>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<LoginResponse> Login(LoginRequestOwn requestOwn)
        {
            return await this._login.Execute(requestOwn);
        }
        /// <inheritdoc/>
        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("refresh-token")]
        public async Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request)
        {
            return await this._refreshToken.Execute(request);
        }
        /// <inheritdoc/>
        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("sign-out")]
        public Task<SignOutResponse> SignOut(SignOutRequest request)
        {
            return this._signOut.Execute(request);
        }
        ///// <inheritdoc/>
        //[AllowAnonymous]
        //[HttpPost]
        //[Routes("register")]
        //public async Task<RegisterResponse> Register(RegisterRequest request)
        //{
        //    return await _register.Execute(request);
        //}
    }
}
