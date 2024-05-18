using ACL.Application.UseCases.Login.Request;
using ACL.Application.UseCases.Login.Response;

namespace ACL.Application.UseCases.Login
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }
}
