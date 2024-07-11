using Notification.Application.Features.Auth.Login;
using Notification.Application.Features.Auth.Login.Request;
using Notification.Application.Features.Auth.Login.Response;
using Notification.Application.Features.Auth.RefreshToken;
using Notification.Application.Features.Auth.RefreshToken.Request;
using Notification.Application.Features.Auth.RefreshToken.Response;
using Notification.Application.Features.Auth.Register;
using Notification.Application.Features.Auth.SignOut;
using Notification.Application.Features.Auth.SignOut.Request;
using Notification.Application.Features.Auth.SignOut.Response;
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
            _loginUseCase = loginUseCase;
            _refreshTokenUseCase = refreshTokenUseCase;
            _signOutUseCase = signOutUseCase;
            _registerUseCase = registerUseCase;
        }
        /// <inheritdoc/>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _loginUseCase.Execute(request);
        }
        /// <inheritdoc/>
        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("refresh-token")]
        public async Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request)
        {
            return await _refreshTokenUseCase.Execute(request);
        }
        /// <inheritdoc/>
        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("sign-out")]
        public Task<SignOutResponse> SignOut(SignOutRequest request)
        {
            return _signOutUseCase.Execute(request);
        }
        ///// <inheritdoc/>
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("register")]
        //public async Task<RegisterResponse> Register(RegisterRequest request)
        //{
        //    return await _registerUseCase.Execute(request);
        //}
    }
}
