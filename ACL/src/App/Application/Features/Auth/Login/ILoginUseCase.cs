using App.Application.Features.Auth.Login.Request;
using App.Application.Features.Auth.Login.Response;

namespace App.Application.Features.Auth.Login
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }
}
