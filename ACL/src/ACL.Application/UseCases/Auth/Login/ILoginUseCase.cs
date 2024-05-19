using ACL.Application.UseCases.Auth.Login.Request;
using ACL.Application.UseCases.Auth.Login.Response;

namespace ACL.Application.UseCases.Auth.Login
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }
}
