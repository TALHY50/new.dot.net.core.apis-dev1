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
using ACL.Application.UseCases.SignOut;
using ACL.Application.UseCases.SignOut.Request;
using ACL.Application.UseCases.SignOut.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase;
        private readonly RefreshTokenUseCase _refreshTokenUseCase;
        private readonly SignOutUseCase _signOutUseCase;
        private readonly CreateUserUseCase _createUserUseCase;

        public AuthController(
            LoginUseCase loginUseCase,
            RefreshTokenUseCase refreshTokenUseCase,
            SignOutUseCase signOutUseCase,
            CreateUserUseCase createUserUseCase)
        {
            _loginUseCase = loginUseCase;
            _refreshTokenUseCase = refreshTokenUseCase;
            _signOutUseCase = signOutUseCase;
            _createUserUseCase = createUserUseCase;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _loginUseCase.Execute(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request)
        {
            return await _refreshTokenUseCase.Execute(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SignOut")]
        public async Task<SignOutResponse> SignOut(SignOutRequest request)
        {
            return await _signOutUseCase.Execute(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateUser")]
        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            return await _createUserUseCase.Execute(request);
        }
    }
}
