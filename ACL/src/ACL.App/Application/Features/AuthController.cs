using ACL.App.Application.Features.Auth.Login;
using ACL.App.Application.Features.Auth.RefreshToken;
using ACL.App.Application.Features.Auth.Register;
using ACL.App.Application.Features.Auth.SignOut;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.App.Application.Features
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
        //[Routes("register")]
        //public async Task<RegisterResponse> Register(RegisterRequest request)
        //{
        //    return await _registerUseCase.Execute(request);
        //}
    }
}
