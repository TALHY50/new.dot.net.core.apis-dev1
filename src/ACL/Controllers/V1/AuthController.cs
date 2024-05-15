using System.Threading.Tasks;
using ACL.Application.UseCases.CreateUser;
using ACL.Application.UseCases.CreateUser.Request;
using ACL.Application.UseCases.CreateUser.Response;
using ACL.Application.UseCases.Login;
using ACL.Application.UseCases.Login.Request;
using ACL.Application.UseCases.Login.Response;
using ACL.Application.UseCases.RefreshToken;
using ACL.Application.UseCases.RefreshToken.Request;
using ACL.Application.UseCases.RefreshToken.Response;
using ACL.Application.UseCases.Register;
using ACL.Application.UseCases.Register.Request;
using ACL.Application.UseCases.SignOut;
using ACL.Application.UseCases.SignOut.Request;
using ACL.Application.UseCases.SignOut.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Route("api/v1/auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase;
        private readonly RefreshTokenUseCase _refreshTokenUseCase;
        private readonly SignOutUseCase _signOutUseCase;
        private readonly RegisterUseCase _registerUseCase;

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

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _loginUseCase.Execute(request);
        }

        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("refresh-token")]
        public async Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request)
        {
            return await _refreshTokenUseCase.Execute(request);
        }

        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("sign-out")]
        public async Task<SignOutResponse> SignOut(SignOutRequest request)
        {
            return await _signOutUseCase.Execute(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            return await this._registerUseCase.Execute(request);
        }
    }
}
