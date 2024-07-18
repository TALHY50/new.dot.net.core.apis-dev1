using App.Application.Features.Auth.Register.Request;
using App.Application.Features.Auth.Register.Response;

namespace App.Application.Features.Auth.Register
{
    public interface IRegisterUseCase : IUseCase<RegisterRequest, RegisterResponse>
    {
    }
}
