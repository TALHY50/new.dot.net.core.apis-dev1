using ACL.Application.Features.Auth.Login.Request;
using ACL.Application.Features.Auth.Login.Response;

namespace ACL.Application.Features.Auth.Login
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }
}
