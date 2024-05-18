using System.Threading.Tasks;
using ACL.UseCases.UseCases.Login;
using ACL.UseCases.UseCases.Login.Request;
using ACL.UseCases.UseCases.Login.Response;
using ACL.UseCases.UseCases.RefreshToken;
using ACL.UseCases.UseCases.RefreshToken.Request;
using ACL.UseCases.UseCases.RefreshToken.Response;
using ACL.UseCases.UseCases.Register;
using ACL.UseCases.UseCases.Register.Request;
using ACL.UseCases.UseCases.Register.Response;
using ACL.UseCases.UseCases.SignOut;
using ACL.UseCases.UseCases.SignOut.Request;
using ACL.UseCases.UseCases.SignOut.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
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
            this._registerUseCase = registerUseCase;
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
        /// <inheritdoc/>
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            return await this._registerUseCase.Execute(request);
        }
    }
}
