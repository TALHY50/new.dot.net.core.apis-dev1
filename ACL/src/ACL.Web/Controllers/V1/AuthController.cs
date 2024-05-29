using ACL.Application.UseCases.Auth.Login;
using ACL.Application.UseCases.Auth.Login.Request;
using ACL.Application.UseCases.Auth.Login.Response;
using ACL.Application.UseCases.Auth.RefreshToken;
using ACL.Application.UseCases.Auth.RefreshToken.Request;
using ACL.Application.UseCases.Auth.RefreshToken.Response;
using ACL.Application.UseCases.Auth.Register;
using ACL.Application.UseCases.Auth.Register.Request;
using ACL.Application.UseCases.Auth.Register.Response;
using ACL.Application.UseCases.Auth.SignOut;
using ACL.Application.UseCases.Auth.SignOut.Request;
using ACL.Application.UseCases.Auth.SignOut.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
    /// <inheritdoc/>
    [Route("api/v1/auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase;
        private readonly RefreshTokenUseCase _refreshTokenUseCase;
        private readonly SignOutUseCase _signOutUseCase;
        private readonly RegisterUseCase _registerUseCase;
        /// <inheritdoc/>
        public AuthController(
            LoginUseCase loginUseCase,
            RefreshTokenUseCase refreshTokenUseCase,
            SignOutUseCase signOutUseCase,
            RegisterUseCase registerUseCase)
        {
            this._loginUseCase = loginUseCase;
            this._refreshTokenUseCase = refreshTokenUseCase;
            this._signOutUseCase = signOutUseCase;
            this._registerUseCase = registerUseCase;
        }
        /// <inheritdoc/>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await this._loginUseCase.Execute(request);
        }
        /// <inheritdoc/>
        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("refresh-token")]
        public async Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request)
        {
            return await this._refreshTokenUseCase.Execute(request);
        }
        /// <inheritdoc/>
        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("sign-out")]
        public Task<SignOutResponse> SignOut(SignOutRequest request)
        {
            return this._signOutUseCase.Execute(request);
        }
        ///// <inheritdoc/>
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("register")]
        //public async Task<RegisterResponse> Register(RegisterRequest request)
        //{
        //    return await this._registerUseCase.Execute(request);
        //}
    }
}
